using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Product[] products =
            {
                new Product(001, "milk", 8), 
                new Product(002, "bread", 10), 
                new Product(003, "coffee", 50)
            };

            Warehouseman david = new Warehouseman(products);

            ArrayList productRange = new ArrayList();

            productRange.Add(new Product(004, "beer", 15));
            productRange.Add(new Product(005, "whiskey", 40));
            productRange.Add(new Product(006, "wine", 40));

            david.askToAddRange(productRange);

            ArrayList filteredProducts = new ArrayList();

            filteredProducts = david.askToSelect("ee");

            foreach (Product product in filteredProducts)
            {
                Console.WriteLine(product.Name); david.askToRemoveProduct(product);
            }

            foreach (Product product in david.askToDisplayProducts()) 
                Console.WriteLine(product.Name);

        }
    }
}
