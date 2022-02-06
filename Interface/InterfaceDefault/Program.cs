using System;

namespace InterfaceDefault
{
    interface DefaultInterface
    {
        public void Display()
        {
            Console.WriteLine("Test");
        }
    }

    class DefaultInterfaceImplementation: DefaultInterface
    {
        public void Display()
        {
            Console.WriteLine("New version");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //DefaultInterface interfaceTest = new DefaultInterface();
            DefaultInterface test = new DefaultInterfaceImplementation();
            test.Display();

            Console.WriteLine("Hello World!");
        }
    }
}
