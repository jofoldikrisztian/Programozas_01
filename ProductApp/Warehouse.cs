using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp
{
    class Warehouse
    {

        public ArrayList productList = new ArrayList();


        public Warehouse(Product[] products)
        {
            foreach (Product product in products)
            {
                productList.Add(product);
            }
        }

        public void add(Product product)
        {
            productList.Add(product);
        }

        public void remove(Product product)
        {
            productList.Remove(product);
        }

        public void addRange(ArrayList range)
        {
            productList.AddRange(range);
        }

        public ArrayList select(string patternOfName)
        {
            ArrayList filteredList = new ArrayList();

            foreach (Product product in productList)
            {
                bool isContains = product.Name.Contains(patternOfName); 
                if (isContains) filteredList.Add(product);
            }
            return filteredList;
        }

        public ArrayList getProducts()
        {
            return productList;
        }

    }
}
