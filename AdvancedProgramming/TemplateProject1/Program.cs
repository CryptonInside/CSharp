using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateProject2
{
    class Program
    {
        static void Main(string[] args)
        {
            string intsum = sum<int>(10, 20);
            Console.WriteLine(intsum);

            string strsum = sum<string>("Hello ", "world");
            Console.WriteLine(strsum);

            Console.ReadLine();
        }

        static string sum<T>(T value1, T value2)
        {
            return value1.ToString() + value2.ToString();
        }
    }
}
