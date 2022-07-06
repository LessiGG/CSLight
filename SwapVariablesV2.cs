using System;

namespace CSLight
{
    class SwapVariablesV2
    {
        static void Main(string[] args)
        {
            string name = "Пушкин";
            string surname = "Александр";

            Console.WriteLine($"До перестановки: имя {name}, фамилия {surname}");
            
            (name, surname) = (surname, name);
            
            Console.WriteLine($"После перестановки: имя {name}, фамилия {surname}");
        }
    }
}