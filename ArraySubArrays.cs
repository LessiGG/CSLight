using System;

namespace CSLight
{
    class ArraySubArrays
    {
        static void Main(string[] args)
        {
            int count = 1;
            int highestCount = count;
            int[] array = new int[30];
            
            Random random = new Random();
            int minRandomNumber = 0;
            int maxRandomNumber = 25;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minRandomNumber, maxRandomNumber);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
            
            int highestRepeatedNumber = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i-1] == array[i])
                {
                    count++;

                    if (highestCount < count)
                    {
                        highestCount = count;
                        highestRepeatedNumber = array[i - 1];
                    }
                }
                else
                {
                    count = 1;
                }
            }

            Console.WriteLine($"Самое часто повторяющееся число - {highestRepeatedNumber}, количество повторений - {highestCount}");
        }
    }
}
