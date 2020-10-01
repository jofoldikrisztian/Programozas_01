using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugInfoApp
{


    [DebugInfo(45, "Bruce Morgan", "22/6/2019", Message = "Wrong access modifier")]
    [DebugInfo(49, "Dusty Fountain", "11/8/2019", Message = "Unused constructors")]
    class Airplane
    {
        private double fuelConsumption;
        public string Model { get; set; }
        public int PassengerCapacity { get; set; }
        public List<Passenger> Passengers { get; set; }
        public double Range { get; set; }
        public FuelTank Tank { get; set; }


        [DebugInfo(50, "Dusty Fountain", "11/8/2019", Message = "Passengers property not inicialized")]
        public Airplane(double range, int capacity, double level)
        {
            Range = range; 
            fuelConsumption = capacity / range; 
            Tank = new FuelTank(capacity, level); 
            Passengers = new List<Passenger>(PassengerCapacity);
        }

        public void cruise(float kilometers)
        {
            if (Range > kilometers)
            {
                if (Tank.Level >= fuelConsumption * kilometers)
                {
                    Tank.Level -= fuelConsumption * kilometers; 
                    System.Console.WriteLine("Cruise status: OK.");

                }
                else
                {
                    System.Console.WriteLine("{0:0.00}km cruise is not possible because fuel level is too low.", kilometers); 

                    System.Console.WriteLine("{0:0.00}l fuel adding...", kilometers * fuelConsumption - Tank.Level); 
                    
                    addFuel(kilometers * fuelConsumption - Tank.Level); 

                    cruise(kilometers);
                }
            } 
            else 
                System.Console.WriteLine("{0:0.00}km are too much.", kilometers);
        }

        [DebugInfo(55, "Bruce Morgan", "19/10/2019", Message = "Calculation problem.")]
        private void addFuel(double liters)
        {
            if (Tank.Level + liters <= Tank.Capacity) 
                Tank.Level += liters; 
            else Tank.Level = Tank.Capacity;
        }

        public void addPassenger(Passenger passenger)
        {
            if (Passengers.Count < PassengerCapacity) 
                Passengers.Add(passenger); 

            else System.Console.WriteLine("Too much passengers.");
        }

        public void removePassenger(Passenger passenger)
        {
            if (Passengers.Count > 1) 
                Passengers.Remove(passenger); 

            else System.Console.WriteLine("Airplane is empty.");
        }




    }
}
