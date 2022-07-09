using System;

namespace CSLight
{
    class ArrayTask2
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            
            int[,] matrixA = new int[10, 10];
            int maxMatrixValue = int.MinValue;
            int minRandomNumber = 1;
            int maxRandomNumber = 10;

            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    matrixA[i, j] = random.Next(minRandomNumber, maxRandomNumber);
                    
                    if (maxMatrixValue < matrixA[i, j])
                    {
                        maxMatrixValue = matrixA[i, j];
                    }

                    Console.Write(matrixA[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("------------------------------");
            
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    if (matrixA[i, j] == maxMatrixValue)
                    {
                        matrixA[i, j] = 0;
                    }
                    
                    Console.Write(matrixA[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxMatrixValue);
        }
    }
}