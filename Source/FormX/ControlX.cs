using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System.Windows.FormsX
{
    public class ControlX<T> : Control where T : Control
    {
        //http://www.codeproject.com/Articles/26878/Making-Transparent-Controls-No-Flickering

        public ControlX()
        {
            //TODO Coordinaten etc. einnehmen vom Control in dessen bisherigen Element

            //TODO das Element wird hier contained und zwar mit DockStyle = Fill
        }

        /*
         * Idee für WinFormX:
         * ControlX<Control> Klasse erweiterten Modus (z.B. Prozent Ausrichtung und Prozent Größe)
         * außerdem echte Transparenz bieten
         */

        public void SetEventsPropagate(object events)
        {
            //TODO echt ne crazy idee...
        }
    }
}
