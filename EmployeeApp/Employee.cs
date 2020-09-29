using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{

    public enum Gender
    {
        Female,
        Male
    }

    public abstract class Employee
    {
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Gender Gender { get; set; }
    public Address Address { get; set; }

    public Employee()
    {
    }

    protected Employee(int employeeID, string firstName, string lastName, string email, string phone, Gender gender,
        Address address)
    {
        EmployeeID = employeeID;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        Gender = gender;
        Address = address;
    }

    public string getBasicInformation()
    {
        return $"Employee ID : {EmployeeID} " +
               $"Name: {getFullName()} " +
               $"Email: {Email} " +
               $"Address: {Address.City} {Address.State} {Address.Street} {Address.Zip}";
    }

    public string getFullName()
    {
        return FirstName + " " + LastName;
    }

    public abstract string getJobName();
    public abstract double getMonthlySalary();

}

}
