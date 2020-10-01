using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp
{
    class Address
    {
        public Address(string street, string city, string state, int zip)
        {
            Street = street;
            City = city;
            State = state;
            Zip = zip;
        }

        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public int Zip { get; set; }
    }
}
