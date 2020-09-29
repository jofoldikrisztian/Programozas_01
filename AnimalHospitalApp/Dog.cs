using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHospitalApp
{
    class Dog : Animal
    {
        private int feedPeriod;
        private int legsMissing;
        private static readonly int numberOfLegs = 4;
        public string DogSound { get; set; } = "Woof";

        public Dog(DateTime arrival, DateTime departure, int? age = null, Gender gender = Gender.Unknown, string name = "No Name", string sound = "No Sound")
            : base(arrival, departure, age, gender, name, sound)
        {
            feedPeriod = 8;
            legsMissing = 0;
        }

        public Dog(DateTime arrival, DateTime departure, string dogSound, int feedPeriod, int legsMissing,
            int? age = null, Gender gender = Gender.Unknown, string name = "No Name", string sound = "No Sound")
            : base(arrival, departure, age, gender, name, sound)
        {
            this.feedPeriod = feedPeriod; 
            this.legsMissing = legsMissing; 
            DogSound = dogSound;
        }

        public int getNumberOfLegs()
        {
            return numberOfLegs - legsMissing;
        }

        public int getFeedsPerDay()
        {
            return 24 / feedPeriod;
        }

        public override void makeSound()
        {
            Console.WriteLine($"{Name} says {Sound} and {DogSound}");
        }


    }
}
