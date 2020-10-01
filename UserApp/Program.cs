using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserApp
{
    class Program
    {
        static void Main(string[] args)
        {


            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string inputDirPath = Path.Combine(appDirectory, "input");
            string inputFilePath = Path.Combine(inputDirPath, "users.txt");

            if (!Directory.Exists(inputDirPath))
            {
                Directory.CreateDirectory(inputDirPath);
            }

            string[] content = ReadFile(inputFilePath);


            Console.WriteLine(content.Length + "row(s) has been read.");

            List<User> users = new List<User>();
            foreach (var user in content)
            {
                users.Add(new User(user));
            }

            Console.WriteLine("{0,25} {1,25} {2,20} {3,6} {4,25} {5,40} {6,30} {7,35}",
                "Name", "Street", "City", "State", "DateOfBirth", "Email", "Username", "Password");

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            string outPutDirPath = Path.Combine(appDirectory, "output");
            string outPutFilePath = Path.Combine(outPutDirPath, "users_mod.txt");
            if (!Directory.Exists(outPutFilePath))
            {
                Directory.CreateDirectory(outPutDirPath);
            }

            WriteFile(outPutFilePath, users);


            Statistics stat = new Statistics(users);

            Console.WriteLine("Youngest user: {0}", stat.getYoungest().FullName + "\n\r");

        }

        private static string[] ReadFile(string path)
        {
            List<string> list = new List<string>();

            try
            {
                if (path == null)
                {
                    throw new ArgumentNullException(nameof(path), "Doesn't exist");
                }

                if (path.Length == 0)
                {
                    throw new ArgumentException("Argument is empty");
                }

                using (StreamReader streamReader = new StreamReader(path, Encoding.Default))
                {
                    string item;
                    while ((item = streamReader.ReadLine()) != null)
                    {
                        list.Add(item);
                    }
                }
            }
            catch (ArgumentNullException argumentNullException)
            {
                Console.WriteLine(argumentNullException.Message);
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                Console.WriteLine(fileNotFoundException.Message);
            }

            return list.ToArray();
        }


        private static void WriteFile(string path, List<User> users)
        {
            using (StreamWriter streamWriter = new StreamWriter(path, true))
            {
                streamWriter.WriteLine("{0,25} {1,25} {2,20} {3,6} {4,25} {5,40} {6,30} {7,35}",
                    "Name", "Street", "City", "State", "DateOfBirth", "Email", "Username", "Password");

                foreach (User user in users) streamWriter.WriteLine("{0,25} {1,25} {2,20} {3,6} {4,25} {5,40} {6,30} {7,35}", 
                    user.FullName, user.Address.Street, user.Address.City, user.Address.State, user.dateOfBirth.ToString("dd, MMMM, yyyy"),
                    user.Email, user.UserName, user.Password);
            }
        }
    }
}
