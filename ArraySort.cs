using System;

namespace CSLight
{
    class ArraySort
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            Random random = new Random();
            
            Console.WriteLine("Исходный массив:");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 10);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine("\nОтсортированный массив:");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i+1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        (array[i], array[j]) = (array[j], array[i]);
                    }
                }
                
                Console.Write(array[i] + " ");
            }
        }
    }
}