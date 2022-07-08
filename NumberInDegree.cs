using System;

namespace CSLight
{
    class NumberInDegree
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minRandomValue = 0;
            int maxRandomValue = 100;
            int number = random.Next(minRandomValue, maxRandomValue);
            
            int numberToDegree = 2;
            int degreeCount = 0;
            int twoInDegreeOfNumber = 0;

            for (int i = numberToDegree; i <= number * numberToDegree; i*= numberToDegree)
            {
                degreeCount++;
                twoInDegreeOfNumber = i;
            }
            
            Console.WriteLine(number);
            Console.WriteLine(degreeCount);
            Console.WriteLine(twoInDegreeOfNumber);
        }
    }
}