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
            
            int firstDivider = 3;
            int secondDivider = 5;
            int numbersSum = 0;

            for (int i = number; i > 0; i--)
            {
                if (i % firstDivider == 0 || i % secondDivider == 0)
                    numbersSum += i;
            }

            Console.WriteLine($"Сумма всех чисел кратных {firstDivider} и {secondDivider} в диапазоне до {number} включительно: {numbersSum}");
        }
    }
}
