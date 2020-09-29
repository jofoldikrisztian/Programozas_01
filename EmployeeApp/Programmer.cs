using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public class Programmer : FullTimeEmployee, IProgrammer
    {
        public Programmer(int employeeID, string firstName, string lastName, string email, string phone, Gender gender, Address address, double annualSalary) 
            : base(employeeID, firstName, lastName, email, phone, gender, address, annualSalary) { }

        public override string getJobName()
        {
            return "CSharp Coding";
        }

        public void doJob()
        {
            Console.WriteLine("Coding CSharp...");
        }
    }
}