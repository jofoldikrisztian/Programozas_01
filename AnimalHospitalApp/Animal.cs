using System;
using System.Linq;

namespace AnimalHospitalApp
{
    public enum Gender { Female, Male, Unknown }

    class Animal
    {
        public DateTime ArriveDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public Gender Gender { get; set; }

        private int? age;

        private string name;

        protected string sound;

        protected AnimalIDInfo animalId;


        public Animal(DateTime arrival, DateTime departure)
            : this(arrival, departure, null, AnimalHospitalApp.Gender.Unknown, "No Name", "No Sound")
        {

        }

        public Animal(DateTime arrival, DateTime departure, int age)
            : this(arrival, departure, age, Gender.Unknown, "No Name", "No Sound")
        {

        }

        public Animal(DateTime arrival, DateTime departure, int age, Gender gender)
            : this(arrival, departure, age, gender, "No Name", "No Sound")
        {

        }

        public Animal(DateTime arrival, DateTime departure, int? age, Gender gender, string name, string sound)
        {
            ArriveDate = arrival;
            DepartureDate = departure;
            Gender = gender;
            this.Age = age;
            this.Name = name;
            this.Sound = sound;
        }

        public void setAnimalIDInfo(int idNum, string owner)
        {
            animalId = new AnimalIDInfo();
            animalId.IDNum = idNum;
            animalId.Owner = owner;
        }

        public int? getAnimalId()
        {
            return animalId?.IDNum;
        }

        public string getAnimalOwner()
        {
            return animalId?.Owner;
        }

        public virtual void makeSound()
        {
            //Console.WriteLine($"{Name} says {Sound}");
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Any(char.IsDigit))
                {
                    name = "No Name";
                }

                name = value;
            }
        }

        public int? Age
        {
            get => age;
            set
            {
                if (age < 0) age = null;
                age = value;
            }
        }

        public string Sound
        {
            get => sound;
            set
            {
                if (sound.Length < 3)
                    sound = "No Sound";
                sound = value;
            }
        }

        public class AnimalHealth
        {
            public bool isHealthyWeight(double height, double weight)
            {
                return weight / height >= .18 && weight / height <= .27;
            }
        }
    }
}
