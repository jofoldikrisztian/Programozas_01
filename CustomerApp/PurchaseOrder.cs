using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CustomerApp
{
    public class PurchaseOrder
    {
        [XmlIgnore] 
        public int id;
        [XmlIgnore]
        public int customerId; 
        public Address shipTo; 
        public string orderDate;
        [XmlArray("items")]
        public OrderedItem[] orderedItems;
        public decimal subTotal; 
        public decimal shipCost; 
        public decimal totalCost;
    }
}
