using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAppv2
{
    public class ContactInfo {
        public int ID
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public string Phone
        {
            get; set;
        }

        public override string ToString()
        {
            return Email + ", " + Phone;
        }

    }
}
