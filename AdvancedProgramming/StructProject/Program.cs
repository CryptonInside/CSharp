using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p;
            p.FirstName = "Сергей";
            Console.WriteLine("Имя: " + p.FirstName);
            //Console.WriteLine("Фамилия: " + p.LastName);

            Person p1 = new Person();
            Console.WriteLine("Фамилия 1: " + p1.LastName);

            Person p2 = new Person("Михаил", "Фленов");
            Console.WriteLine("Фамилия 2: " + p2.LastName);

            Console.ReadLine();
        }
    }

    struct Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            age = 18;
        }

        public string FirstName;
        public string LastName;
        public int age;
    }
}
