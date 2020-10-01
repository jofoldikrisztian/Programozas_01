using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DebugInfoApp
{
    class Program
    {
        private static void PrintCustomAttribute(Type t)
        {
            foreach (Attribute attributes in t.GetCustomAttributes(false))
            {
                DebugInfo li = (DebugInfo) attributes;
                if (null != li)
                {
                    Console.WriteLine("Log no: {0}", li.BugNo);
                    Console.WriteLine("Tester: {0}", li.Developer);
                    Console.WriteLine("Last Reviewed: {0}", li.LastReview);
                    Console.WriteLine("Remarks: {0}", li.Message);
                }
            }
        }

        private static void PrintConstructorAttribute(Type t)
        {
            foreach (ConstructorInfo ci in t.GetConstructors())
            {
                foreach (Attribute a in ci.GetCustomAttributes(false))
                {
                    DebugInfo li = (DebugInfo) a;

                    if (null != li)
                    {
                        Console.WriteLine("Bug no: {0}, for Method: {1}", li.BugNo, ci.Name);
                        Console.WriteLine("Tester: {0}", li.Developer);
                        Console.WriteLine("Last Reviewed: {0}", li.LastReview);
                        Console.WriteLine("Remarks: {0}", li.Message);
                    }
                }
            }

        }



        private static void PrintMethodAttribute(Type t)
        {
            foreach (MethodInfo mi in t.GetMethods())
            {
                foreach (Attribute a in mi.GetCustomAttributes())
                {
                    if (a is DebugInfo)
                    {
                        DebugInfo li = (DebugInfo) a;
                        if (null != li)
                        {
                            Console.WriteLine("Bug no: {0}, for Method: {1}", li.BugNo, mi.Name);
                            Console.WriteLine("Tester: {0}", li.Developer);
                            Console.WriteLine("Last Reviewed: {0}", li.LastReview);
                            Console.WriteLine("Remarks: {0}", li.Message);
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            Airplane airbusA380 = new Airplane(14800, 253983, rnd.Next(100, 253983));
            PrintCustomAttribute(typeof(Airplane));
            PrintConstructorAttribute(typeof(Airplane));
            PrintMethodAttribute(typeof(Airplane));


            Console.ReadKey();
        }

    }
} 

