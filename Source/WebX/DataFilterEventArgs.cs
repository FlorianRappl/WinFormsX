using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.WebX
{
    /// <summary>
    /// Represents the event arguments for filtering data.
    /// </summary>
    public class DataFilterEventArgs : AjaxEventArgs
    {
        /// <summary>
        /// The Constructor.
        /// </summary>
        /// <param name="options">The given AjaxRequest options.</param>
        /// <param name="data">The received data as a string.</param>
        public DataFilterEventArgs(AjaxRequestOptions options, string data) : base(options)
        {
            OriginalData = data;
            ModifiedData = data;
        }

        /// <summary>
        /// Gets the original data.
        /// </summary>
        public string OriginalData { get; private set; }
        
        /// <summary>
        /// Gets or sets the modified data.
        /// </summary>
        public string ModifiedData { get; set; }
    }
}
