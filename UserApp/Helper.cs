using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UserApp
{
    static class Helper
    {

        public static string convertToMD5(string input)
        {
            MD5 md5 = MD5.Create();
            StringBuilder sb = new StringBuilder();

            try
            {
                byte[] hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(input));

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return sb.ToString();
        }

        public static string modifyUsername(string fullName)
        {
            return fullName.Replace(' ', '.').ToLower();
        }
    }
}
