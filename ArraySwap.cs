using System;

namespace CSLight
{
    class ArraySwap
    {
        static void Main(string[] args)
        {
            int[] array = new int[0];
            bool isExit = false;

            string sumCommand = "sum";
            string exitCommand = "exit";

            while (isExit == false)
            {
                Console.WriteLine($"Введите число, {exitCommand} или {sumCommand}: ");
                string userInput = Console.ReadLine();

                if (userInput == sumCommand)
                {
                    int arraySum = 0;
                    for (int i = 0; i < array.Length; i++)
                    {
                        arraySum += array[i];
                    }

                    Console.WriteLine($"Сумма массива - {arraySum}");
                }
                else if (userInput == exitCommand)
                {
                    isExit = true;
                }
                else
                {
                    int[] tempArray = new int[array.Length + 1];
                    int arrayItem = Convert.ToInt32(userInput);

                    for (int i = 0; i < array.Length; i++)
                    {
                        tempArray[i] = array[i];
                    }
                    
                    tempArray[tempArray.Length - 1] = arrayItem;
                    array = tempArray;
                }
            }
        }
    }
}
