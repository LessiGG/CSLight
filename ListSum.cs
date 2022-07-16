using System;
using System.Collections.Generic;

namespace CSLight
{
    class ListSum
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            bool isExit = false;

            string sumCommand = "sum";
            string exitCommand = "exit";

            while (isExit == false)
            {
                Console.WriteLine($"Введите число, {exitCommand} или {sumCommand}: ");
                string userInput = Console.ReadLine();
                bool gotNumber = int.TryParse(userInput, out int result);

                if (gotNumber == true)
                {
                    numbers.Add(Convert.ToInt32(userInput));
                }
                else if (userInput == sumCommand)
                {
                    int numbersSum = 0;
                    
                    foreach (var number in numbers)
                    {
                        numbersSum += number;
                    }

                    Console.WriteLine($"Сумма введенных чисел - {numbersSum}");
                }
                else if (userInput == exitCommand)
                {
                    isExit = true;
                }
                else
                {
                    Console.WriteLine("Было введено не число.");
                }
            }
        }
    }
}