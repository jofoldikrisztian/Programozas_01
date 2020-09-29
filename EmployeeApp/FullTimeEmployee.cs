using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public abstract class FullTimeEmployee : Employee
    {
        public double AnnualSalary { get; set; }

        public FullTimeEmployee() : base() { }

        protected FullTimeEmployee(int employeeID, string firstName, string lastName, string email, string phone,
            Gender gender, Address address, double annualSalary)
            : base(employeeID, firstName, lastName, email, phone, gender, address)
        {
            AnnualSalary = annualSalary;
        }

        public override double getMonthlySalary()
        {
            return AnnualSalary / 12;
        }
    }
}
