using System;

namespace CSLight
{
    class ArrayTask1
    {
        static void Main(string[] args)
        {
            int[,] array = new int[5, 5];
            Random random = new Random();
            int secondRowSum = 0;
            int firstColumnMult = 1;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int minRandomNumber = 1;
                    int maxRandomNumber = 5;
                    array[i, j] = random.Next(minRandomNumber, maxRandomNumber);
                    Console.Write(array[i, j] + " ");
                }
                
                Console.WriteLine();
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                secondRowSum += array[1, i];
            }
            
            for (int i = 0; i < array.GetLength(1); i++)
            {
                firstColumnMult *= array[i, 0];
            }

            Console.WriteLine(secondRowSum);
            Console.WriteLine(firstColumnMult);
        }
    }
}
