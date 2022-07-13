using System;

namespace CSLight
{
    class ShuffleArray
    {
        static void Main(string[] args)
        {
            int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.WriteLine("Массив до перемешивания:");
            PrintArray(array);

            Shuffle(array);
            
            Console.WriteLine("Массив после перемешивания:");
            PrintArray(array);
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }

        static void Shuffle(int[] array)
        {
            Random random = new Random();
            
            for (int i = 0; i < array.Length; i++)
            {
                SwapArrayElements(array, i, random.Next(array.Length - 1));
            }
        }

        static void SwapArrayElements(int[] array, int firstIndex, int secondIndex)
        {
            (array[firstIndex], array[secondIndex]) = (array[secondIndex], array[firstIndex]);
        }
    }
}