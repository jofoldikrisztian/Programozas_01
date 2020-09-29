using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teszt
{
    class Dog : Animal
    {
        public Dog()
        {

        }


        public override void doSomething()
        {
            Console.WriteLine($"dog is doing something.... ");
        }
    }
}
