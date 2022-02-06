using System;

namespace EnumTest
{
    class Program
    {
        enum MyColors
        {
            Red = 100,
            Green = 200,
            Blue = 300
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Enum Names");

            foreach (string str in Enum.GetNames(typeof(MyColors)))
                Console.WriteLine(str);

            Console.WriteLine("Enum Values");
            foreach (int i in Enum.GetValues(typeof(MyColors)))
                Console.WriteLine(i);

            Console.WriteLine("Введите имя цвета");
            string currentColor = Console.ReadLine();
            MyColors myColor1 = (MyColors)Enum.Parse(typeof(MyColors), currentColor, true);
            Console.WriteLine("Вы выбрали " + myColor1 + " - " +  (int)myColor1);

            object myColorObject;
            if (Enum.TryParse(typeof(MyColors), currentColor, true, out myColorObject))
            {
                myColor1 = (MyColors)myColorObject;
                Console.WriteLine("Вы выбрали " + myColor1 + " - " + (int)myColor1);
            }

            Console.WriteLine("Введите имя значение цвета");
            currentColor = Console.ReadLine();
            int colorIntValue = Int32.Parse(currentColor);
            MyColors myColor2 = (MyColors)colorIntValue;
            Console.WriteLine("Вы выбрали " + myColor2 + " - " + (int)myColor2);

            Console.ReadLine();
        }
    }
}
