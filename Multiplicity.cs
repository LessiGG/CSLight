﻿using System;

namespace CSLight
{
    class Multiplicity
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            int numbersSum = 0;

            for (int i = randomNumber; i > 0; i--)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    numbersSum += i;
            }

            Console.WriteLine($"Сумма всех чисел кратных 3 и 5 в диапазоне до {randomNumber} включительно: {numbersSum}");
        }
    }
}