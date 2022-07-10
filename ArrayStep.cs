using System;

namespace CSLight
{
    class ArrayStep
    {
        static void Main(string[] args)
        {
            int[] array = {1, 2, 3, 4, 5, 12};
            
            int steps = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < array.Length - steps; i++)
            {
                (array[i], array[i + steps]) = (array[i + steps], array[i]);
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
