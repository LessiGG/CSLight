using System;

namespace CSLight
{
    class RepeatMessage
    {
        static void Main(string[] args)
        {
            string userMessage;
            int repeatCount;

            Console.Write("Введите сообщение которое будет повторяться: ");
            userMessage = Console.ReadLine();

            Console.Write("Введите сколько раз сообщение должно повториться: ");
            repeatCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < repeatCount; i++)
            {
                Console.WriteLine(userMessage);
            }
        }
    }
}