using System;

namespace CSLight
{
    class ArraySwap
    {
        static void Main(string[] args)
        {
            int lengthArray = 0;
            int[] array = new int[lengthArray];
            int[] tempArray = new int[lengthArray];
            int arraySum = 0;

            while (true)
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
                    break;
                }

                if (userInput == "exit")
                {
                    break;
                }

                int arrayItem = Convert.ToInt32(userInput);
                lengthArray += 1;

                for (int i = 0; i < tempArray.Length; i++)
                {
                    tempArray[i] = array[i];
                }

                array = new int[lengthArray];

                for (int i = 0; i < tempArray.Length; i++)
                {
                    array[i] = tempArray[i];
                }

                array[lengthArray - 1] = arrayItem;
                tempArray = array;
            }
        }
    }
}