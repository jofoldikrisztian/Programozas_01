using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teszt
{
    class Animal
    {



        public Animal()
        {
           
        }

        public virtual void doSomething()
        {
            Console.WriteLine($"animal is doing something.");
        }

    }
}
