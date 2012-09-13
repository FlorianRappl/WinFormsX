using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Security;

namespace System.WebX
{
    /// <summary>
    /// Class containing extension methods for Uri objects.
    /// </summary>
    public static class UrlExtensions
    {
        const int BUFFER_SIZE = 32 * 1024;

        /// <summary>
        /// Performs a request to the current URL.
        /// </summary>
        /// <param name="url">Target of the request.</param>
        /// <returns>The content of the response in bytes.</returns>
        public static byte[] Request(this Uri url)
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(AcceptAllCertifications);
            var request = WebRequest.Create(url) as HttpWebRequest;
            var answer = new MemoryStream();
            var bytes = new byte[BUFFER_SIZE];
            var n = 0;

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                try
                {
                    using (var stream = response.GetResponseStream())
                    {
                        while ((n = stream.Read(bytes, 0, BUFFER_SIZE)) != 0)
                            answer.Write(bytes, 0, n);
                    }
                }
                catch (WebException ex)
                {
                    using (var stream = (ex.Response as HttpWebResponse).GetResponseStream())
                    {
                        while ((n = stream.Read(bytes, 0, BUFFER_SIZE)) != 0)
                            answer.Write(bytes, 0, n);
                    }
                }
            }

            return answer.ToArray();
        }

        private static bool AcceptAllCertifications(object sender, 
            System.Security.Cryptography.X509Certificates.X509Certificate certification, 
            System.Security.Cryptography.X509Certificates.X509Chain chain, 
            System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        /// <summary>
        /// Performs a JSON request to the current URL.
        /// </summary>
        /// <param name="url">Target of the request.</param>
        /// <returns>The content of the response as a string (should be stringified JSON).</returns>
        public static string JsonRequest(this Uri url)
        {
            var json = string.Empty;
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.ContentLength = 0;
            request.ContentType = "application/json";

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var stream = response.GetResponseStream();

                    using (var ms = new MemoryStream())
                    {
                        var bytes = new byte[BUFFER_SIZE];
                        var n = 0;

                        while ((n = stream.Read(bytes, 0, BUFFER_SIZE)) != 0)
                            ms.Write(bytes, 0, n);

                        json = Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }

            return json;
        }

        /// <summary>
        /// Performs an AJAX request with default options.
        /// </summary>
        /// <param name="url">The url where the request is sent to.</param>
        /// <returns>The AjaxRequest object.</returns>
        public static AjaxRequest Ajax(this Uri url)
        {
            return url.Ajax(AjaxRequestOptions.Default);
        }

        /// <summary>
        /// Performs an AJAX reuqest with custom options.
        /// </summary>
        /// <param name="url">The url where the request is sent to.</param>
        /// <param name="options">The custom options of the current request.</param>
        /// <returns>The AjaxRequest object.</returns>
        public static AjaxRequest Ajax(this Uri url, AjaxRequestOptions options)
        {
            options.Url = url.ToString();
            return Ajax(options);
        }

        /// <summary>
        /// Performs an AJAX reuqest with custom options.
        /// </summary>
        /// <param name="options">The custom options of the current request as an anonymous object.</param>
        /// <returns>The AjaxRequest object.</returns>
        public static AjaxRequest Ajax(object options)
        {
            var opt = new AjaxRequestOptions();
            var oft = typeof(AjaxRequestOptions);
            var rft = options.GetType().GetProperties();

            foreach (var rf in rft)
            {
                if (oft.GetProperty(rf.Name) != null)
                    oft.GetProperty(rf.Name).SetValue(opt, rf.GetValue(options, null), null);
            }            

            return Ajax(opt);
        }

        /// <summary>
        /// Performs an AJAX reuqest with custom options.
        /// </summary>
        /// <param name="options">The custom options of the current request.</param>
        /// <returns>The AjaxRequest object.</returns>
        public static AjaxRequest Ajax(AjaxRequestOptions options)
        {
            return new AjaxRequest(options);
        }
    }
}
