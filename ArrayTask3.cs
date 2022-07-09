using System;

namespace CSLight
{
    class ArrayTask3
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] array = new int[30];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 25);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();

            if (array[0] > array[1])
            {
                Console.WriteLine(array[0]);
            }
            
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i] > array[i - 1] && array[i] > array[i + 1])
                {
                    Console.WriteLine(array[i]);
                }
            }
            
            if (array[array.Length -1] > array[array.Length - 2])
            {
                Console.WriteLine(array[array.Length -1]);
            }
        }
    }
}