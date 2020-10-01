using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp
{
    class User
    {
        public DateTime dateOfBirth;
        public Address Address { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }



        public User(string user)
        {
            string[] u = user.Split(';');
            FullName = u[0];
            Address = new Address(u[1], u[2], u[3], int.Parse(u[4]));
            dateOfBirth = DateTime.Parse(u[5]);
            Email = u[6];
            UserName = Helper.modifyUsername(u[7]);
            Password = Helper.convertToMD5(u[8]);
        }

        public override string ToString()
        {
            return string.Format("{0,25} {1,25} {2,20} {3,6} {4,25} {5,40} {6,30} {7,35}",
                FullName, Address.Street, Address.City, Address.State, dateOfBirth.ToString("dd, MMMM, yyyy"), Email, UserName, Password);
        }


   

    }
}
