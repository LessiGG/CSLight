using System;

namespace CSLight
{
    class ArraySubArrays
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int count = 1;
            int highestCount = 1;
            
            //int[] array = new int[30];
            int[] array = new int[] {5, 5, 9, 9, 9, 5, 5};

            for (int i = 0; i < array.Length; i++)
            {
                //array[i] = random.Next(0, 10);

                Console.Write(array[i] + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == array[i + 1])
                {
                    count++;

                    if (count < highestCount)
                    {
                        highestCount = count;
                    }
                }
            }
        }
    }
}