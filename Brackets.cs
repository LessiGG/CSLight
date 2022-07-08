using System;

namespace CSLight
{
    class Brackets
    {
        static void Main(string[] args)
        {
            string brackets = ")((()()))()(";
            int count = 0;
            int maxCount = 0;

            foreach (var bracket in brackets)
            {
                if (bracket == '(')
                {
                    count++;
                    
                    if (count > maxCount)
                    {
                        maxCount = count;
                    }
                }

                else if (bracket == ')')
                {
                    count--;
                }
                
                if (count < 0)
                    break;
            }
            
            if (count != 0)
                Console.WriteLine("Последовательность некоректная.");
            else
            {
                Console.WriteLine(maxCount);
            }
        }
    }
}