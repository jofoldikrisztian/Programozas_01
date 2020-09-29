using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeApp.Helper;

namespace EmployeeApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Generator.ID = 1; 
            Random rnd = new Random(); 
            Generator employeeGenerator = new Generator();
            List<Programmer> programmers = new List<Programmer>(); 
            List<Tester> testers = new List<Tester>();

            using (StreamWriter file = new StreamWriter(@"employees.txt", true))
            {
                file.WriteLine("{0,3} {1,20} {2,6} {3,30} {4,15} {5,15} {6,20} {7,20} {8,30} {9,10} {10,10}", "EID", "Name", "Gender", "Email", "Phone", "Job", "City", "State", "Street", "Zip", "Salary");
                for (int i = 0; i < 20; i++)
                {
                    Employee employee = employeeGenerator.generateEmployee(); 

                    if (employee is Programmer) 
                        programmers.Add(employee as Programmer);
                    else
                    {
                        Tester tester = employee as Tester; 
                        testers.Add(tester);

                    } 
                    
                    file.WriteLine("{0,3} {1,20} {2,6} {3,30} {4,15} {5,15} {6,20} {7,20} {8,30} {9,10} {10,10:#.##}", 
                        employee.EmployeeID, 
                        employee.getFullName(),
                        employee.Gender, 
                        employee.Email, 
                        employee.Phone, 
                        employee.getJobName(), 
                        employee.Address.City, 
                        employee.Address.State,
                        employee.Address.Street,
                        employee.Address.Zip, 
                        employee.getMonthlySalary());
                }
            }
            Console.WriteLine("PROGRAMMERS");
            foreach (Programmer programmer in programmers)
            {
                Console.WriteLine(programmer.getFullName());
            }

            Console.WriteLine("TESTERS");
            foreach (Tester tester in testers)
            {
                Console.WriteLine(tester.getFullName());
            }
        }

    }
}
