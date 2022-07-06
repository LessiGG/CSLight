using System;

namespace CSLight
{
    class SwapVariablesV1
    {
        static void Main(string[] args)
        {
            string temporaryStorage;
            string name = "Пушкин";
            string surname = "Александр";

            Console.WriteLine($"До перестановки: имя {name}, фамилия {surname}");
            
            temporaryStorage = name;
            name = surname;
            surname = temporaryStorage;
            
            Console.WriteLine($"После перестановки: имя {name}, фамилия {surname}");
        }
    }
}