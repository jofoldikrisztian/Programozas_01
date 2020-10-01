using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp
{
    class Warehouseman
    {
        Warehouse warehouse;

        public Warehouseman(Product[] products)
        {
            warehouse = new Warehouse(products);
        }

        public void askToAddProduct(Product product)
        {
            warehouse.add(product);
        }

        public void askToRemoveProduct(Product product)
        {
            warehouse.remove(product);
        }

        public void askToAddRange(ArrayList range)
        {
            warehouse.addRange(range);
        }

        public ArrayList askToSelect(string patternOfName)
        {
            ArrayList filteredList = warehouse.select(patternOfName); return filteredList;
        }

        public ArrayList askToDisplayProducts()
        {
            return warehouse.getProducts();
        }
    }
}
