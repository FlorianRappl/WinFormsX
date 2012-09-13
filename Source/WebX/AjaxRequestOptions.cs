using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Net;

namespace System.WebX
{
    /// <summary>
    /// Contains all possible options for the AJAX request.
    /// </summary>
    public class AjaxRequestOptions
    {
        #region Members

        IDictionary<string, string> headers;
        IDictionary<AjaxDataType, AjaxFilterHandler> filters;
        IDictionary<HttpStatusCode, AjaxResponseHandler> statusCodes;
        string originalUrl;
        string directUrl;
        string queryUrl;

        #endregion

        #region ctor

        /// <summary>
        /// The constructor
        /// </summary>
        public AjaxRequestOptions()
        {
            Accepts = string.Empty;
            Timeout = 45;
            DiscardRequestedWith = false;
            Async = true;
            ProcessData = true;
            MimeType = "application/x-www-form-urlencoded";
            DataType = AjaxDataType.Guess;
            Type = AjaxRequestType.GET;
            headers = new Dictionary<string, string>();
            filters = new Dictionary<AjaxDataType, AjaxFilterHandler>();
            statusCodes = new Dictionary<HttpStatusCode, AjaxResponseHandler>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Url for the request.
        /// </summary>
        public string Url
        {
            get { return originalUrl; }
            set
            {
                originalUrl = value;
                queryUrl = string.Empty;

                if (originalUrl.Contains("?"))
                {
                    var idx = originalUrl.IndexOf('?');
                    directUrl = originalUrl.Substring(0, idx);
                    queryUrl = originalUrl.Substring(idx + 1);
                }
                else
                    directUrl = originalUrl;
            }
        }

        /// <summary>
        /// Gets or sets the accept string in the header.
        /// </summary>
        public string Accepts { get; set; }

        /// <summary>
        /// Gets or sets if the request is executed asynchronously.
        /// </summary>
        public bool Async { get; set; }

        /// <summary>
        /// Gets or sets the delegate of a method that should be executed before the actual request.
        /// </summary>
        public AjaxHandler BeforeSend { get; set; }

        /// <summary>
        /// Gets or sets the content type string in the header.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the data that is transmitted (anonymous object).
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the datatype that is expected from the response.
        /// </summary>
        public AjaxDataType DataType { get; set; }

        /// <summary>
        /// Gets or sets if the data should already be processed.
        /// </summary>
        public bool ProcessData { get; set; }

        /// <summary>
        /// Gets or sets the timeout of the request in seconds.
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// Gets or sets the type of the request (GET, POST, PUT, DELETE).
        /// </summary>
        public AjaxRequestType Type { get; set; }

        /// <summary>
        /// Gets or sets the mime type of the request.
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Gets or sets the username to use for authorization.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password to use for authorization.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets the headers for this request.
        /// </summary>
        public IDictionary<string, string> Headers { get { return headers; } }

        /// <summary>
        /// Gets the filters (to sanatize the initial response) for this request.
        /// </summary>
        public IDictionary<AjaxDataType, AjaxFilterHandler> Filters { get { return filters; } }

        /// <summary>
        /// Gets the status code handlers for this request.
        /// </summary>
        public IDictionary<HttpStatusCode, AjaxResponseHandler> StatusCodeHandlers { get { return statusCodes; } }

        /// <summary>
        /// Gets or sets the handler that is invoked on completion.
        /// </summary>
        public AjaxHandler Complete { get; set; }

        /// <summary>
        /// Gets or sets the handler that is invoked on failure.
        /// </summary>
        public AjaxHandler Error { get; set; }

        /// <summary>
        /// Gets or sets the handler that is invoked on success.
        /// </summary>
        public AjaxResponseHandler Success { get; set; }

        /// <summary>
        /// Gets or sets if the X-Requested-With header should not be sent.
        /// </summary>
        public bool DiscardRequestedWith { get; set; }

        /// <summary>
        /// Gets the direct url for this request.
        /// </summary>
        internal string DirectUrl
        {
            get { return directUrl; }
        }

        /// <summary>
        /// Gets the encoded Name Value pairs for this request.
        /// </summary>
        internal string EncodedNameValuePairs
        {
            get
            {
                var query = new StringBuilder();

                if (Data != null)
                {
                    var k = 0;
                    var props = Data.GetType().GetProperties();

                    foreach (var prop in props)
                    {
                        query.Append(k++ > 0 ? "&" : string.Empty);
                        query.Append(prop.Name);
                        query.Append("=");
                        query.Append(Uri.EscapeDataString(prop.GetValue(Data, null).ToString()));
                    }
                }

                if (!string.IsNullOrEmpty(queryUrl))
                {
                    query.Append(query.Length > 0 ? "&" : string.Empty);
                    query.Append(queryUrl);
                }

                return query.ToString();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a converter (to sanatize the initial response) for a given type to the list of converters.
        /// </summary>
        /// <param name="type">The type which should use the converter.</param>
        /// <param name="function">The delegate to your converter.</param>
        /// <returns>The current instance.</returns>
        public AjaxRequestOptions AddConverter(AjaxDataType type, AjaxFilterHandler function)
        {
            if (filters.ContainsKey(type))
                filters[type] = function;
            else
                filters.Add(type, function);

            return this;
        }

        /// <summary>
        /// Removes a converter (to sanatize the initial response) from the list of converters.
        /// </summary>
        /// <param name="type">The type which uses this converter.</param>
        /// <returns>The current instance.</returns>
        public AjaxRequestOptions RemoveConverter(AjaxDataType type)
        {
            if (filters.ContainsKey(type))
                filters.Remove(type);

            return this;
        }

        /// <summary>
        /// Adds a header to the list of custom headers.
        /// </summary>
        /// <param name="key">The key of the header entry to add.</param>
        /// <param name="value">The value of the header entry.</param>
        /// <returns>The current instance.</returns>
        public AjaxRequestOptions AddHeader(string key, string value)
        {
            if (headers.ContainsKey(key))
                headers[key] = value;
            else
                headers.Add(key, value);

            return this;
        }

        /// <summary>
        /// Removes a header from the list of custom headers.
        /// </summary>
        /// <param name="type">The key of the header entry to remove.</param>
        /// <returns>The current instance.</returns>
        public AjaxRequestOptions RemoveHeader(string key)
        {
            if (headers.ContainsKey(key))
                headers.Remove(key);

            return this;
        }

        /// <summary>
        /// Adds a handler for a status code to the list of handlers.
        /// </summary>
        /// <param name="statusCode">The status code which should be handled separately.</param>
        /// <param name="handler">The delegate to your handler.</param>
        /// <returns>The current instance.</returns>
        public AjaxRequestOptions AddStatusCodeHandler(HttpStatusCode statusCode, AjaxResponseHandler handler)
        {
            if (statusCodes.ContainsKey(statusCode))
                statusCodes[statusCode] = handler;
            else
                statusCodes.Add(statusCode, handler);

            return this;
        }

        /// <summary>
        /// Removes a handler for a status code from the list of handlers.
        /// </summary>
        /// <param name="statusCode">The status code which should not be handled separately any more.</param>
        /// <returns>The current instance.</returns>
        public AjaxRequestOptions RemoveStatusCodeHandler(HttpStatusCode statusCode)
        {
            if (statusCodes.ContainsKey(statusCode))
                statusCodes.Remove(statusCode);

            return this;
        }

        #endregion

        #region Static

        /// <summary>
        /// Gets the default options.
        /// </summary>
        public static AjaxRequestOptions Default 
        {
            get
            {
                return new AjaxRequestOptions();
            }
        }

        #endregion
    }
}
