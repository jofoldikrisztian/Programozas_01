using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teszt
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Animal> tyuk = new List<Animal>()
            {
                new Dog(),
                new horse()
            };

            foreach (var animal in tyuk)
            {
                animal.doSomething();
            }



            Console.ReadKey();
        }
    }
}
