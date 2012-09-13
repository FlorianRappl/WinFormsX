using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.WebX
{
    /// <summary>
    /// Represents a delegate to handle events from the AjaxRequest class.
    /// </summary>
    /// <param name="sender">The instance of the AjaxRequest class that initiated the request.</param>
    /// <param name="e">The AjaxEventArgs along with this handler.</param>
    public delegate void AjaxHandler(AjaxRequest sender, AjaxEventArgs e);

    /// <summary>
    /// Represents a delegate to handle events from filtering in the AjaxRequest class.
    /// </summary>
    /// <param name="sender">The instance of the AjaxRequest class that initiated the request.</param>
    /// <param name="e">The DataFilterEventArgs along with this handler.</param>
    public delegate void AjaxFilterHandler(AjaxRequest sender, DataFilterEventArgs e);

    /// <summary>
    /// Represents a delegate to handle the response in the AjaxRequest class.
    /// </summary>
    /// <param name="sender">The instance of the AjaxRequest class that initiated the request.</param>
    /// <param name="e">The AjaxResponseEventArgs along with this handler.</param>
    public delegate void AjaxResponseHandler(AjaxRequest sender, AjaxResponseEventArgs e);
}
