using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAppv2
{
    public class Program
    {

        List<Employee> employees = new List<Employee>()
        {
            new Employee
            {
                ID = 111,
                CompanyID = 111,
                FirstName = "Joseph",
                LastName = "Evans",
                Salary = new List<double>()
                {
                    120.2, 356.2, 160.1, 100.99
                }
            },
            new Employee
            {
                ID = 112,
                CompanyID = 111,
                FirstName = "Savannah",
                LastName = "Tower",
                Salary = new List<double>()
                {
                    80.9, 90.4, 94.3, 20.3
                }
            },
            new Employee
            {
                ID = 113,
                CompanyID = 112,
                FirstName = "David",
                LastName = "Langley",
                Salary = new List<double>()
                {
                    200.1, 320, 2, 255, 5, 300, 9
                }
            },
            new Employee
            {
                ID = 114,
                CompanyID = 111,
                FirstName = "James",
                LastName = "Pardee",
                Salary = new List<double>()
                {
                    30.3, 40.5, 35.6, 43.2
                }
            }
        };

        public List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo
            {
                ID = 111,
                Email = "JosephMEvans@jourrapide.com",
                Phone = "660-9286465"
            },
            new ContactInfo
            {
                ID = 112,
                Email = "SavannahCTower@rhyta.com",
                Phone = "312-9723816"
            },
            new ContactInfo
            {
                ID = 113,
                Email = "DavidJLangley@dayrep.com",
                Phone = "423-3036671"
            },
            new ContactInfo
            {
                ID = 114,
                Email = "JamesAPardee@teleworm.us",
                Phone = "978-296-9082"
            }
        };

        public List<Company> companies = new List<Company>()
        {
            new Company
            {
                ID = 111,
                Name = "Friendly Advice"
            },
            new Company
            {
                ID = 112,
                Name = "Success Is Yours"
            },
            new Company
            {
                ID = 113,
                Name = "Destiny Realty Solutions"
            }
        };


        static void Main(string[] args)
        {

            Program prg = new Program();

            #region where clause

            IEnumerable<Employee> employees =
                from employee in prg.employees
                where employee.ID > 111
                select employee;

            Console.WriteLine("#query1 result:");
            foreach (Employee employee in employees)
                Console.WriteLine(employee);

            IEnumerable<string> firstNames =
                from employee in prg.employees
                where employee.ID > 111
                select employee.FirstName;

            Console.WriteLine("\n\r#query2 result:");
            foreach (string firstName in firstNames)
                Console.WriteLine(firstName);

            IEnumerable<ContactInfo> contactInfos =
                from employee in prg.employees
                where employee.ID > 111
                select employee.GetContactInfo(prg, employee.ID);

            Console.WriteLine("\n\r#query3 result:");
            foreach (ContactInfo contactInfo in contactInfos)
                Console.WriteLine(contactInfo);

            IEnumerable<double> salaries =
                from employee in prg.employees
                where employee.ID > 111
                select employee.Salary[0];

            Console.WriteLine("\n\r#query4 result:");
            foreach (int salary in salaries)
                Console.WriteLine("First Salary = {0}", salary);

            IEnumerable<double> averages =
                from employee in prg.employees
                where employee.ID > 111
                select employee.Salary.Average();

            Console.WriteLine("\n\r#query5 result:");
            foreach (double average in averages)
                Console.WriteLine("Average = {0}", average);

            var names =
                from employee in prg.employees
                where employee.ID > 111
                select new
                {
                    employee.FirstName,
                    employee.LastName
                }; //anonymous type 

            Console.WriteLine("\n\r#query6 result:");
            foreach (var name in names)
                Console.WriteLine("{0}, {1}", name.LastName, name.FirstName);

            #endregion

            #region group clause

            var groupedfirstNames =
                from employee in prg.employees
                group employee by employee.FirstName[0]
                into g
                orderby g.Key
                select g;

            Console.WriteLine("\n\r#query7 result:");

            foreach (IGrouping<char, Employee> gfirstName in groupedfirstNames)
            {
                Console.WriteLine(gfirstName.Key);

                foreach (var employee in gfirstName) //explicit type
                    Console.WriteLine(" {0}, {1}", employee.FirstName, employee.LastName);
            }

            Console.WriteLine("\n\r#query8 result:");

            var isAverageGt =
                from employee
                    in prg.employees
                group employee
                    by employee.Salary.Average() >= 120;

            foreach (var value in isAverageGt)
            {
                Console.WriteLine(value.Key == true ? "High salaries" : "Low salaries");

                foreach (var employee in value)
                    Console.WriteLine(" {0}, {1}:{2}", employee.FirstName, employee.LastName, employee.Salary.Average());
            }

            #endregion

            #region join clause

            IEnumerable<ContactInfo> contactInfosOfAverageGt =
                from employee in prg.employees
                where employee.Salary.Average() > 120
                join ci in prg.contacts
                    on employee.ID
                    equals ci.ID
                select ci;

            Console.WriteLine("\n\r#query9 result:");

            foreach (ContactInfo ci in contactInfosOfAverageGt)
                Console.WriteLine("ID = {0}, Email = {1}", ci.ID, ci.Email);

            var idsAndEmails =
                from employee in prg.employees
                join ci in prg.contacts on employee.ID equals ci.ID
                select new
                {
                    EmployeeID = employee.ID,
                    Email = ci.Email
                };

            Console.WriteLine("\n\r#query10 result:");

            foreach (var idAndEmail in idsAndEmails)
                Console.WriteLine("{0,-10}{1}", idAndEmail.EmployeeID, idAndEmail.Email);

            Console.WriteLine("===");

            Console.WriteLine("{0} items in 1 group.", idsAndEmails.Count());

            var employeeGrps1 =
                from ei in prg.companies
                join employee in prg.employees
                    on ei.ID equals employee.CompanyID
                    into emplGrp
                select emplGrp;

            int totalItems = 0;

            Console.WriteLine("\n\r#query11 result:");

            foreach (var employeeGrp in employeeGrps1)
            {
                Console.WriteLine("Group:");
                foreach (var employee in employeeGrp)
                {
                    totalItems++;
                    Console.WriteLine(" {0,-10}{1}", employee.FirstName, employee.ID);
                }
            }

            Console.WriteLine("===");
            Console.WriteLine("{0} items in {1} unnamed groups", totalItems, employeeGrps1.Count());

            var employeeGrps2 =
                from cs in prg.companies
                orderby cs.ID
                join employee in prg.employees
                    on cs.ID equals employee.CompanyID into emplGrp
                select new
                {
                    Name = cs.Name,
                    Employees = from subEmployee in emplGrp orderby subEmployee.FirstName select subEmployee
                };

            totalItems = 0;
            Console.WriteLine("\n\r#query12 result:");
            foreach (var employeeGrp in employeeGrps2)
            {
                Console.WriteLine(employeeGrp.Name);
                foreach (var employee in employeeGrp.Employees)
                {
                    totalItems++;
                    Console.WriteLine(" {0,-10} {1}", employee.FirstName, employee.CompanyID);
                }
            }

            Console.WriteLine("===");
            Console.WriteLine("{0} items in {1} named groups", totalItems, employeeGrps2.Count());

            var employeeGrps3 =
                from cs in prg.companies
                join employee in prg.employees on cs.ID equals employee.CompanyID into emplGrp
                select emplGrp.DefaultIfEmpty(new Employee()
                {
                    ID = 211,
                    FirstName = "Nothing!",
                    LastName = "Nothing!",
                    CompanyID = cs.ID,
                    Salary = new List<double>() { 2130.3, 4210.5, 3525.6, 4342.2 }
                });



            totalItems = 0;

            Console.WriteLine("\n\r#query13 result:");

            foreach (var employeeGrp in employeeGrps3)
            {
                Console.WriteLine("Group:", employeeGrp.Count());
                foreach (var employee in employeeGrp)
                {
                    totalItems++;
                    Console.WriteLine(" {0,-10} {1}", employee.FirstName, employee.CompanyID);
                }
            }

            Console.WriteLine("===");
            Console.WriteLine("{0} items in {1} groups", totalItems, employeeGrps3.Count());

            #endregion }
        }
    }
}
