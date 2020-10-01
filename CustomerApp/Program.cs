using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CustomerApp
{
    class Program
    {

        List<Address> addresses = new List<Address>()
            {
                new Address { id = 111, name = "William A. Klein", street = "2231 Huntz Lane", city = "Cambridge", state = "Massachusetts(MA)", zip = "02141" },
                new Address { id = 112, name = "Zulma S. Baker", street = "2318 Harley Brook Lane", city = "Johnstown", state = "Pennsylvania(PA)", zip = "15903" },
                new Address { id = 113, name = "Richard J. McCarty", street = "2025 Heavner Court", city = "Humboldt", state = "Iowa(IA)", zip = "50548" },
                new Address { id = 114, name = "Marsha B. Victoria", street = "2662 Collins Avenue", city = "Westerville", state = "Ohio(OH)", zip = "43081" },
                new Address { id = 115, name = "Joseph J. Barrett", street = "3207 Rockford Road", city = "Bedford", state = "Massachusetts(MA)", zip = "01730" },
            };

        List<Customer> customers = new List<Customer>()
            {
                new Customer { id = 111, addressId = 111, cardNumber = "774-745-7897", pin = 5088 },
                new Customer { id = 112, addressId = 112, cardNumber = "803-274-1684", pin = 8037 },
                new Customer { id = 113, addressId = 113, cardNumber = "313-967-1576", pin = 3135 },
                new Customer { id = 114, addressId = 114, cardNumber = "607-745-4425", pin = 3154 },
                new Customer { id = 115, addressId = 115, cardNumber = "954-385-7283", pin = 4077 },
            };

        List<OrderedItem> orderedItems = new List<OrderedItem>()
            {
                new OrderedItem { itemName = "greeting card", unitPrice = (decimal)5.09, quantity = 2 },
                new OrderedItem { itemName = "lamp shade", unitPrice = (decimal)12.10, quantity = 3 },
                new OrderedItem { itemName = "cup", unitPrice = (decimal)35.12, quantity = 10 },
                new OrderedItem { itemName = "ballon", unitPrice = (decimal)42.11, quantity = 100 },
                new OrderedItem { itemName = "shovel", unitPrice = (decimal)40.29, quantity = 1 },
            };

        List<PurchaseOrder> purchaseOrder = new List<PurchaseOrder>()
            {
                new PurchaseOrder { id=111, customerId = 111, orderDate = DateTime.Now.ToLongDateString() },
                new PurchaseOrder { id=112, customerId = 111, orderDate = DateTime.Now.ToLongDateString() },
                new PurchaseOrder { id=113, customerId = 113, orderDate = DateTime.Now.ToLongDateString() },
                new PurchaseOrder { id=114, customerId = 114, orderDate = DateTime.Now.ToLongDateString() },
                new PurchaseOrder { id=115, customerId = 112, orderDate = DateTime.Now.ToLongDateString() },
            };
        static void Main(string[] args)
        {
            Program prg = new Program();
            prg.createPO(prg, "purchaseOrder.xml");
            prg.readPo("purchaseOrder.xml");
        }
        private void createPO(Program prg, string filename)
        {
            XmlSerializer xmlSerializer = 
                new XmlSerializer(typeof(List<PurchaseOrder>), 
                    new XmlRootAttribute("purchaseOrders"));

            foreach (OrderedItem item in prg.orderedItems) 
                item.Calculate();

            IEnumerable<Address> addressQuery = 
                from po in prg.purchaseOrder 
                join cust in prg.customers 
                    on po.customerId equals cust.id 
                join addr in prg.addresses 
                    on cust.addressId equals addr.id 
                select addr;

            int i = 0; Random rnd = new Random(); 
            
            foreach (Address address in addressQuery)
            {
                prg.purchaseOrder[i].shipTo = address; int itemsAmount = rnd.Next(1, 5 + 1);

                OrderedItem[] items = new OrderedItem[itemsAmount];
                
                for (int j = 0; j < itemsAmount; j++) 
                    items[j] = orderedItems.ElementAt(rnd.Next(1, 4 + 1));

                prg.purchaseOrder[i].orderedItems = items;

                decimal subTotal = new decimal();
                foreach (OrderedItem oi in items) 
                    subTotal += oi.lineTotal;
                prg.purchaseOrder[i].subTotal = subTotal;

                prg.purchaseOrder[i].shipCost = (decimal)12.50;

                prg.purchaseOrder[i].totalCost = prg.purchaseOrder[i].subTotal + prg.purchaseOrder[i].shipCost; i++;
            }

            using (FileStream fs = new FileStream(filename, FileMode.Create)) xmlSerializer.Serialize(fs, purchaseOrder);
        }

        private void readPo(string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<PurchaseOrder>),
                new XmlRootAttribute("purchaseOrders"));
            xmlSerializer.UnknownNode += new XmlNodeEventHandler(serializer_UnknownNode);
            xmlSerializer.UnknownAttribute += new XmlAttributeEventHandler(serializer_UnknownAttribute);
            FileStream fs = new FileStream(filename, FileMode.Open); List<PurchaseOrder> pos;

            pos = (List<PurchaseOrder>)xmlSerializer.Deserialize(fs);

            foreach (PurchaseOrder po in pos)
            {
                Console.WriteLine("OrderDate: " + po.orderDate);

                Address address = po.shipTo; readAddress(address, "Ship To:"); OrderedItem[] items = po.orderedItems; Console.WriteLine("Items to be shipped:"); foreach (OrderedItem item in items) { Console.WriteLine("\t" + item.itemName + "\t" + item.unitPrice + "\t" + item.quantity + "\t" + item.lineTotal); }
                Console.WriteLine("\n\t\t\t\t\t Subtotal\t" + po.subTotal + "\n\t\t\t\t\t Shipping\t" + po.shipCost + "\n\t\t\t\t\t Total\t\t" + po.totalCost);
            }
        }

        protected void readAddress(Address a, string label)
        {
            Console.WriteLine(label);
            Console.Write("\t" + a.name + "\n\t" + a.street + "\n\t" + a.city + "\t" + a.state + "\n\t" + a.zip + "\n");
        }

        protected void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            Console.WriteLine("Unknown Node:" + e.Name + "\t" + e.Text);
        }

        protected void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            System.Xml.XmlAttribute attr = e.Attr; 
            Console.WriteLine("Unknown attribute " + attr.Name + "='" + attr.Value + "'");
        }





    }


}
