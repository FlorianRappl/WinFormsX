using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.WebX
{
    /// <summary>
    /// Represents the ajax event arguments for having a response.
    /// </summary>
    public class AjaxResponseEventArgs : AjaxEventArgs
    {
        public AjaxResponseEventArgs (AjaxRequestOptions options, string text, object response) : base(options)
	    {
            ResponseText = text;
            Response = response;
	    }

        /// <summary>
        /// Gets the received text.
        /// </summary>
        public string ResponseText { get; private set; }

        /// <summary>
        /// Gets the requested object from the response.
        /// </summary>
        public object Response { get; private set; }
    }
}
