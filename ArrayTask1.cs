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
            int firstColumnSum = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int minRandomNumber = 0;
                    int maxRandomNumber = 100;
                    array[i, j] = random.Next(minRandomNumber, maxRandomNumber);
                    Console.Write(array[i, j] + " ");
                    
                    if (i == 1) // Вторая строка
                    {
                        secondRowSum += array[i, j];
                    }

                    if (j == 0) // Первый столбик
                    {
                        firstColumnSum += array[i, j];
                    }
                }
                
                Console.WriteLine();
            }

            Console.WriteLine(secondRowSum);
            Console.WriteLine(firstColumnSum);
        }
    }
}