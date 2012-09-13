using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Net;
using System.IO;
using System.Net.Cache;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace System.WebX
{
    /// <summary>
    /// This class performs AjaxRequests.
    /// </summary>
    public class AjaxRequest
    {
        #region Events

        /// <summary>
        /// The event that is invoked once the request completed.
        /// </summary>
        public event AjaxHandler OnComplete;

        /// <summary>
        /// The event that is invoked once the request fails.
        /// </summary>
        public event AjaxHandler OnError;

        /// <summary>
        /// The event that is invoked once the request succeeds.
        /// </summary>
        public event AjaxResponseHandler OnSuccess;

        #endregion

        #region Members

        IDictionary<string, string> header;
        string body;
        HttpWebRequest request;
        HttpWebResponse response;
        Task task;

        #endregion

        #region ctor

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="options"></param>
        public AjaxRequest(AjaxRequestOptions options)
        {
            Options = options;
            header = new Dictionary<string, string>();
            body = string.Empty;
            var url = options.DirectUrl;

            if (options.Type == AjaxRequestType.GET)
                url = options.DirectUrl + "?" + options.EncodedNameValuePairs;

            request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Method = Options.Type.ToString();
            request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            request.Timeout = Options.Timeout * 1000;

            if(!string.IsNullOrEmpty(Options.MimeType))
                request.ContentType = Options.MimeType;

            request.AllowAutoRedirect = true;
            request.Date = DateTime.Now;

            if(!string.IsNullOrEmpty(Options.Accepts))
                request.Accept = Options.Accepts;

            if (!string.IsNullOrEmpty(Options.UserName))
                SetAuthorizationHeader(Options.UserName, Options.Password ?? string.Empty);

            // See: http://en.wikipedia.org/wiki/List_of_HTTP_header_fields
            if(!Options.DiscardRequestedWith)
                request.Headers.Add("X-Requested-With", "XMLHttpRequest");

            foreach (string key in Options.Headers.Keys)
                request.Headers[key] = Options.Headers[key].ToString();

            if (Options.Complete != null)
                OnComplete += Options.Complete;

            if (Options.Success != null)
                OnSuccess += Options.Success;

            if (Options.Error != null)
                OnError += Options.Error;

            task = new Task(PerformRequest);
            ReadyState = WebX.ReadyState.Uninitialized;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Aborts the current Ajax request.
        /// </summary>
        /// <returns>The current instance.</returns>
        public AjaxRequest Abort()
        {
            if (Running)
            {
                request.Abort();
                Running = false;
                task.Dispose();
            }

            return this;
        }

        /// <summary>
        /// Starts the current Ajax request.
        /// </summary>
        /// <returns>The current instance.</returns>
        public AjaxRequest Invoke()
        {
            if (!Running)
            {
                ReadyState = WebX.ReadyState.Open;
                IsResolved = true;
                Running = true;

                if (Options.BeforeSend != null)
                    Options.BeforeSend(this, new AjaxEventArgs(Options));

                if (Options.Async)
                {
                    task.ContinueWith(HandleResponse)
                        .ContinueWith(FinishResponse, TaskScheduler.FromCurrentSynchronizationContext());
                    task.Start();
                }
                else
                {
                    task.RunSynchronously();
                    HandleResponse(task);
                    FinishResponse(task);
                }

                ReadyState = WebX.ReadyState.Sent;
            }

            return this;
        }

        /// <summary>
        /// Creates a XML document from the ResponseText.
        /// </summary>
        /// <returns>The XDocument instance containing the XML nodes.</returns>
        public XDocument CreateXmlObject()
        {
            if (string.IsNullOrEmpty(ResponseText))
                return new XDocument();

            return XDocument.Parse(ResponseText);
        }

        /// <summary>
        /// Creates a JSON object from the ResponseText.
        /// </summary>
        /// <returns>The dynamic JSON object.</returns>
        public dynamic CreateJsonObject()
        {
            if (string.IsNullOrEmpty(ResponseText))
                return new { } as dynamic;

            return DynamicJsonConverter.Instance.Deserialize(ResponseText, typeof(object)) as dynamic;
        }

        #endregion

        #region Private methods

        void SetAuthorizationHeader(string username, string password)
        {
            var authInfo = username + ":" + password;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers.Add("Authorization", "Basic " + authInfo);
        }

        void SetupRequest()
        {
            var query = Options.EncodedNameValuePairs;
            var stream = request.GetRequestStream();
            var content = Encoding.UTF8.GetBytes(query);
            stream.Write(content, 0, content.Length);
        }

        void PerformRequest()
        {
            if (Options.Type != AjaxRequestType.GET)
                SetupRequest();

            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;

                if (response == null)
                    throw;
            }
        }

        void HandleResponse(Task task)
        {
            if (task.IsCompleted && !task.IsFaulted)
            {
                ReadyState = WebX.ReadyState.Receiving;
                StatusCode = response.StatusCode;
                StatusText = response.StatusDescription;
                LastModified = response.LastModified;
                ResponseUrl = response.ResponseUri;
                ResponseType = response.ContentType;
                ReadResponse(response.ContentEncoding);

                foreach (string key in response.Headers.Keys)
                    header.Add(key, response.Headers[key]);
            }
        }

        void FinishResponse(Task task)
        {
            if (task.IsCompleted && !task.IsFaulted)
            {
                ResponseDataType = Options.DataType;
                var ev = new DataFilterEventArgs(Options, ResponseText);

                if (Options.DataType == AjaxDataType.Guess)
                    ResponseDataType = GuessDataType();

                if (Options.Filters.ContainsKey(ResponseDataType))
                    (Options.Filters[ResponseDataType] as AjaxFilterHandler).Invoke(this, ev);
                else
                    DefaultFilter(ev);

                ResponseText = ev.ModifiedData;
                var ro = CreateObject(ResponseDataType);
                var args = new AjaxResponseEventArgs(Options, ResponseText, ro);
                IsResolved = true;

                if (Options.StatusCodeHandlers.ContainsKey(StatusCode))
                    (Options.StatusCodeHandlers[StatusCode] as AjaxResponseHandler).Invoke(this, args);

                if (OnSuccess != null)
                    OnSuccess.Invoke(this, args);
            }
            else
            {
                if (OnError != null)
                    OnError.Invoke(this, new AjaxEventArgs(Options));
            }

            ReadyState = WebX.ReadyState.Loaded;

            if (response != null)
                response.Close();

            if (OnComplete != null)
                OnComplete.Invoke(this, new AjaxEventArgs(Options));
        }

        object CreateObject(AjaxDataType dt)
        {
            if (Options.ProcessData)
            {
                var methods = GetType().GetMethods();

                foreach (var method in methods)
                    if (method.Name.Equals("Create" + dt.ToString() + "Object"))
                        return method.Invoke(this, null);
            }
            
            return ResponseText;
        }

        void ReadResponse(string encoding)
        {
            if (string.IsNullOrEmpty(encoding))
                encoding = "utf-8";

            var enc = Encoding.GetEncoding(encoding) ?? Encoding.UTF8;
            var buffer = new byte[4096];
            var length = 0;
            var sb = new StringBuilder();
            var stream = response.GetResponseStream();

            while ((length = stream.Read(buffer, 0, buffer.Length)) > 0)
                sb.Append(enc.GetString(buffer, 0, length));

            ResponseText = sb.ToString();
        }

        void DefaultFilter(DataFilterEventArgs ev)
        {
            //TODO
        }

        AjaxDataType GuessDataType()
        {
            //TODO

            if (ResponseType.Contains("application/x-javascript"))
                return AjaxDataType.Jsonp;
            else if (ResponseType.Contains("application/atom+xml"))
                return AjaxDataType.Xml;

            var sanatized = ResponseText.Replace(" ", string.Empty);

            if (sanatized.StartsWith("{"))
                return AjaxDataType.Json;
            else if (sanatized.StartsWith("<?xml"))
                return AjaxDataType.Xml;
            else if (sanatized.StartsWith("<"))
                return AjaxDataType.Html;

            return AjaxDataType.Script;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the headers from the response.
        /// </summary>
        public IDictionary<string, string> ReponseHeader { get { return header; } }

        /// <summary>
        /// Gets a value if the request has been rejected.
        /// </summary>
        public bool IsRejected { get; private set; }

        /// <summary>
        /// Gets a value if the request has been completed successfully.
        /// </summary>
        public bool IsResolved { get; private set; }

        /// <summary>
        /// Gets the options that have been used for this request.
        /// </summary>
        public AjaxRequestOptions Options { get; private set; }

        /// <summary>
        /// Gets the url that responded to the request.
        /// </summary>
        public Uri ResponseUrl { get; private set; }

        /// <summary>
        /// Gets the mime type of the response.
        /// </summary>
        public string ResponseType { get; private set; }

        /// <summary>
        /// Gets the status description.
        /// </summary>
        public string StatusText { get; private set; }

        /// <summary>
        /// Gets the status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// Gets the response text.
        /// </summary>
        public string ResponseText { get; private set; }

        /// <summary>
        /// Gets the date of the last modification of the response.
        /// </summary>
        public DateTime LastModified { get; private set; }

        /// <summary>
        /// Gets the current ready state.
        /// </summary>
        public ReadyState ReadyState { get; private set; }

        /// <summary>
        /// Gets the (detected) response type.
        /// </summary>
        public AjaxDataType ResponseDataType { get; private set; }

        /// <summary>
        /// Gets the current status of the web request.
        /// </summary>
        public bool Running { get; private set; }

        #endregion

        #region Static Methods

        /// <summary>
        /// Creates (i.e. spawns an instance and starts the request) a new AjaxRequest.
        /// </summary>
        /// <param name="options">An AjaxRequestOptions instance with all options set.</param>
        /// <returns>The AjaxRequest instance.</returns>
        public static AjaxRequest Create(AjaxRequestOptions options)
        {
            return new AjaxRequest(options).Invoke();
        }

        /// <summary>
        /// Creates (i.e. spawns an instance and starts the request) a new AjaxRequest.
        /// </summary>
        /// <param name="options">An anonymous object with all necessary options set.</param>
        /// <returns>The AjaxRequest instance.</returns>
        public static AjaxRequest Create(object options)
        {
            var opt = new AjaxRequestOptions();
            var oprops = opt.GetType().GetProperties();
            var props = options.GetType().GetProperties();

            foreach (var prop in props)
            {
                foreach (var oprop in oprops)
                {
                    if (prop.Name.Equals(oprop))
                    {
                        oprop.SetValue(opt, prop.GetValue(options, null), null);
                        break;
                    }
                }
            }

            return AjaxRequest.Create(opt);
        }

        #endregion
    }
}
