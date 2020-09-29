using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public abstract class ContractEmployee : Employee
    {
        public double HourlyPay { get; set; }
        public double TotalHours { get; set; }
        public ContractEmployee() { }

        protected ContractEmployee(int employeeID, string firstName, string lastName, string email, string phone, Gender gender, Address address, double hourlyPay, double totalHours) : base(employeeID, firstName, lastName, email, phone, gender, address) { HourlyPay = hourlyPay; TotalHours = totalHours; }

        public override double getMonthlySalary() { return TotalHours * HourlyPay; }
    }
}