using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerApp
{

    public delegate void ButtonClickHandler(object sender, EventArgs e);
    class Button
    {

        public event ButtonClickHandler ButtonClickedEvent;

        public void SimulateClick()
        {
            InvokeClicked(EventArgs.Empty);
        }

        private void InvokeClicked(EventArgs e)
        {
            ButtonClickedEvent?.Invoke(this, e);
        }

        public override string ToString()
        {
            return "Button Clicked!";
        }


    }
}
