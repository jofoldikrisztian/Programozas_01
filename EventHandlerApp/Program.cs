using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Button button = new Button(); 
            button.ButtonClickedEvent += new ButtonClickHandler(Button_Clicked); 
            button.SimulateClick();

        }

        public static void Button_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine(sender.ToString());
        }
    }
}
