using System;

namespace CSLight
{
    class NumberRange
    {
        static void Main(string[] args)
        {
            int startValue = 5;
            int endValue = 96;
            int step = 7;
            
            for (int i = startValue; i <= endValue; i+= step)
            {
                Console.Write(i + " ");
            }
        }
    }
}