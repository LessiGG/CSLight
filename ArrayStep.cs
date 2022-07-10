using System;

namespace CSLight
{
    class ArrayStep
    {
        static void Main(string[] args)
        {
            int[] array = {1, 2, 3, 4, 5, 12};

            for (int i = 0; i < array.Length - 1; i++)
            {
                (array[i], array[i + 1]) = (array[i + 1], array[i]);
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}