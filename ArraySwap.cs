using System;

namespace CSLight
{
    class ArraySwap
    {
        static void Main(string[] args)
        {
            int[] array = new int[1];
            int arraySum = 0;

            bool isExitConditionMet = false;

            while (isExitConditionMet == false)
            {
                Console.WriteLine($"Введите число, exit или sum: ");
                string userInput = Console.ReadLine();

                if (userInput == "sum")
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        arraySum += array[i];
                    }

                    Console.WriteLine($"Сумма массива - {arraySum}");
                    arraySum = 0;
                }

                else if (userInput == "exit")
                {
                    isExitConditionMet = true;
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
