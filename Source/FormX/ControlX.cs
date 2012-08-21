using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System.Windows.FormsX
{
    // CHANGE INTERNAL TO public ONCE PUBLISHABLE
    internal class ControlX<T> : Control where T : Control
    {
        //http://www.codeproject.com/Articles/26878/Making-Transparent-Controls-No-Flickering

        public ControlX()
        {
            //TODO Inherit coordinates etc. of former / usual element

            //TODO Contain the element with DockStyle.Fill
        }

        /*
         * Idea for WinFormsX:
         * ControlX<Control> class with extended mode (e.g. fluid design with relative units like percent)
         * provide real transparency
         */

        public void SetEventsPropagate(object events)
        {
            //TODO This method could allow events to propagate
        }
    }

    //TODO:
    //Include PRISM style classes to creating composite regions
    //http://www.codeproject.com/Articles/48287/Getting-Started-with-Prism-2-1-for-WPF
    //http://compositewpf.codeplex.com/

    //TODO:
    //Include some MVVM style classes - so that binding gets a lot easier

    //TODO:
    //Binding to value of control (like width) -- if value changes then an animation should occur! [ CSS3 Transition style ]
}
