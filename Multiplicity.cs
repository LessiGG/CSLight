using System;

namespace CSLight
{
    class Multiplicity
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minValue = 0;
            int maxValue = 100;
            int number = random.Next(minValue, maxValue);
            
            int multiplicityBy3 = 3;
            int multiplicityBy5 = 5;
            int numbersSum = 0;

            for (int i = number; i > 0; i--)
            {
                if (i % multiplicityBy3 == 0 || i % multiplicityBy5 == 0)
                    numbersSum += i;
            }

            Console.WriteLine($"Сумма всех чисел кратных {multiplicityBy3} и {multiplicityBy5} в диапазоне до {number} включительно: {numbersSum}");
        }
    }
}
