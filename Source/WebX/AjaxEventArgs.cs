using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.WebX
{
    /// <summary>
    /// Represents the plain Ajax event arguments.
    /// </summary>
    public class AjaxEventArgs : EventArgs
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="options">We expect some options here.</param>
        public AjaxEventArgs(AjaxRequestOptions options)
        {
            Options = options;
        }

        /// <summary>
        /// Gets the passed AjaxRequestOptions.
        /// </summary>
        public AjaxRequestOptions Options { get; private set; }
    }
}
