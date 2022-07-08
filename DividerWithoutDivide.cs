using System;

namespace CSLight
{
    class DividerWithoutDivide
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            
            int minRandomNumber = 1;
            int maxRandomNumber = 28;
            int divider = random.Next(minRandomNumber, maxRandomNumber);
            
            int minNumber = 100;
            int maxNumber = 1000;
            
            int dividersCount = 0;
 
            for (int i = 0; i < maxNumber; i += divider)
            {
                if (i > minNumber)
                {
                    dividersCount++;
                }
            }

            Console.WriteLine(dividersCount);
        }
    }
}
