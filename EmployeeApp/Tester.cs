using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public class Tester : ContractEmployee, ITester
    {
        public Tester(int employeeID, string firstName, string lastName, string email, string phone, Gender gender, Address address, double hourlyPay, double totalHours) 
            : base(employeeID, firstName, lastName, email, phone, gender, address, hourlyPay, totalHours) { }

        public override string getJobName()
        {
            return "Tester";
        }

        public void doJob()
        {
            Console.WriteLine("Testing...");
        }
    }
}