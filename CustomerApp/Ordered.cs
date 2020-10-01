using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp
{
    public class OrderedItem
    {
        public string itemName; 
        public decimal unitPrice; 
        public int quantity; 
        public decimal lineTotal;

        public void Calculate()
        {
            lineTotal = unitPrice * quantity;
        }
    }
}
