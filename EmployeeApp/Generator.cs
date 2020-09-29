using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Helper
{
    public class Generator
    {
        public static int ID;
        private Random rnd = new Random();

        private string[] firstNamesFemale =
        {
            "Alexandra", "Alison", "Maria", "Sophie", "Wanda"
        };

        private string[] firstNamesMale =
        {
            "Brandon", "David", "Gordon", "Jonathan", "Peter"
        };

        private string[] lastNames =
        {
            "Abraham", "Campbell", "Ellison", "Henderson", "Johnston"
        };

        private string[] streets =
        {
            "2708 Adonais Way", "4154 Cherry Tree Drive", "3466 Wilmar Farm Road", "1949 Jadewood Drive",
            "501 Blane Street"
        };

        private string[] cities =
        {
            "Atlanta", "Jacksonville", "Lanham", "Wheatfield", "Fairview Heights"
        };

        private string[] states =
        {
            "Georgia(GA)", "Florida(FL)", "Maryland(MD)", "Indiana(IN)", "Missouri(MO)"
        };

        private string[] phones =
        {
            "5022020178", "8622089310", "6165501041", "5803816344", "9189754494"
        };

        private string generateFirstNamesFemale()
        {
            return firstNamesFemale[rnd.Next(firstNamesFemale.Length)];
        }

        private string generateFirstNamesMale()
        {
            return firstNamesMale[rnd.Next(firstNamesMale.Length)];
        }

        private string generateLastNames()
        {
            return lastNames[rnd.Next(lastNames.Length)];
        }

        private string generateStreets()
        {
            return streets[rnd.Next(streets.Length)];
        }

        private string generateCities()
        {
            return cities[rnd.Next(cities.Length)];
        }

        private string generateStates()
        {
            return states[rnd.Next(states.Length)];
        }

        private int generateZips()
        {
            return rnd.Next(1, 9999);
        }

        private string generatePhones()
        {
            return phones[rnd.Next(phones.Length)];
        }

        private Gender generateGender()
        {
            bool isFemale = rnd.Next(100) < 50 ? true : false;

            return isFemale ? Gender.Female : Gender.Male;
        }

        private bool generateJob()
        {
            return rnd.Next(100) < 50 ? true : false;
        }

        private Address generateAddress(Address address)
        {
            address.City = generateCities();
            address.State = generateStates();


            address.Street = generateStreets(); address.Zip = generateZips(); return address;
        }

        public Employee generateEmployee()
        {
            Employee employee; 
            string firstName; 
            string lastName;

            if (generateGender().Equals(Gender.Female))
            {
                firstName = generateFirstNamesFemale(); 
                lastName = generateLastNames(); 

                if (generateJob()) 
                    employee = new Programmer(
                        ID, 
                        firstName, 
                        lastName, 
                        ConvertTo.email(firstName, lastName), 
                        ConvertTo.phone(generatePhones()), 
                        Gender.Female, generateAddress(new Address()), 
                        rnd.NextDouble() * 100000); 
                else employee = new Tester(
                    ID, 
                    firstName, 
                    lastName, 
                    ConvertTo.email(firstName, lastName), 
                    ConvertTo.phone(generatePhones()), 
                    Gender.Female, generateAddress(
                        new Address()), 
                    rnd.NextDouble() * 1000, 
                    rnd.NextDouble() * 13);
            }
            else
            {
                firstName = generateFirstNamesMale(); 
                lastName = generateLastNames(); 
                
                if (generateJob()) 
                    employee = new Programmer(
                        ID, 
                        firstName, 
                        lastName, 
                        ConvertTo.email(firstName, lastName), 
                        ConvertTo.phone(generatePhones()), 
                        Gender.Male, generateAddress(
                            new Address()), 
                        rnd.NextDouble() * 100000);
                else employee = new Tester(
                    ID, firstName, 
                    lastName,
                    ConvertTo.email(firstName, lastName), 
                    ConvertTo.phone(generatePhones()), 
                    Gender.Male,
                    generateAddress(new Address()), 
                    rnd.NextDouble() * 1000, 
                    rnd.NextDouble() * 13);
            }
            ID++; 
            return employee;
        }
    }
}