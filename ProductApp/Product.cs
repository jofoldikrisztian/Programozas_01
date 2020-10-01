using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp
{
    class Product
    {

        public Product(int id, string name, int price)
        {
            this.Id = id;
            Name = name;
            Price = price;
        }

        private int Id { get; set; }
        public string Name { get; set; }
        private int Price { get; set; }

    }
}
