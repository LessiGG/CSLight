using System;

namespace CSLight
{
    class DividerWithoutDivide
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int minRandomValue = 1;
            int maxRandomValue = 28;
            int N = random.Next(minRandomValue, maxRandomValue);
            int dividersCount = 0;

            int bottomBorder = 100;
            int topBorder = 1000;

            for (int i = bottomBorder; i < topBorder; i++)
            {
                int divider = i;
                while (divider > 0)
                {
                    divider -= N;
                }

                if (divider == 0)
                {
                    dividersCount++;
                }
            }

            Console.WriteLine(dividersCount);
        }
    }
}