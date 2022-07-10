using System;

namespace CSLight
{
    class ArrayStep
    {
        static void Main(string[] args)
        {
            int[] array = {1, 2, 3, 4, 5, 12, 2, 2, 4, 5, 6, 7, 8, 88, 3, 2, 1};
            
            int steps = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < steps; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
