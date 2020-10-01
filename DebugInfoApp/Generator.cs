using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugInfoApp
{
    class Generator
    {
        private string[] firstNamesFemale = { "Alexandra", "Alison", "Maria", "Sophie", "Wanda" };
        private string[] firstNamesMale = { "Brandon", "David", "Gordon", "Jonathan", "Peter" };
        private string[] lastNames = { "Abraham", "Campbell", "Ellison", "Henderson", "Johnston" };

        private Random rnd = new Random();

        private int genereteAge()
        {
            return rnd.Next(1, 99);
        }

        private string generateFirstNamesFemale()
        {
            return firstNamesFemale[rnd.Next(firstNamesFemale.Length)];
        }

        private string generateFirstNamesMale()
        {
            return firstNamesMale[rnd.Next(firstNamesMale.Length)];
        }

        private string generateGender()
        {
            bool isFemale = rnd.Next(100) < 50 ? true : false; 
            
            return isFemale ? "Female" : "Male";
        }

        private string generateLastNames()
        {
            return lastNames[rnd.Next(lastNames.Length)];
        }

        public Passenger generatePassenger()
        {
            Passenger passenger = new Passenger();
            if (passenger.Gender.Equals("Female")) 
                passenger.Fullname = generateFirstNamesFemale() + " " + generateLastNames(); 
            else passenger.Fullname = generateFirstNamesMale() + " " + generateLastNames(); 
            
            passenger.Age = genereteAge(); 

            passenger.TravelID = generateTravelID();

            return passenger;
        }

        private string generateTravelID()
        {
            return string.Format("T" + rnd.Next(1, 9999));
        }
    }
}
