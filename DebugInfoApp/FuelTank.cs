using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugInfoApp
{
    class FuelTank
    {
    

        public int Capacity { get; set; }
        public double Level { get; set; }


        public FuelTank(int capacity, double level)
        {
            Capacity = capacity;
            Level = level;
        }
    }
}
