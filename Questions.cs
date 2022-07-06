using System;

namespace CSLight
{
    class Questions
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Как вас зовут?");
            string name = Console.ReadLine();
            
            Console.WriteLine("Сколько вам лет?");
            string age = Console.ReadLine();
            
            Console.WriteLine("Какой у вас знак зодиака?");
            string zodiacSign = Console.ReadLine();
            
            Console.WriteLine("Какая у вас профессия?");
            string occupation = Console.ReadLine();

            Console.WriteLine($"Вас зовут {name}, вам {age} лет, ваш знак зодиака {zodiacSign}, ваша профессия {occupation}.");
        }
    }
}