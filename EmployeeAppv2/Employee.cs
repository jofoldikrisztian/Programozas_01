using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAppv2
{
    class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CompanyID { get; set; }
        public List<double> Salary;

        public ContactInfo GetContactInfo(Program program, int id)
        {
            ContactInfo contactInfo = (from ci in program.contacts where ci.ID == id select ci).FirstOrDefault();

            return contactInfo;
        }

        public override string ToString() { return FirstName + " " + LastName + ": " + ID; }
    }
}
