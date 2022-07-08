using System;

namespace CSLight
{
    class PasswordGuess
    {
        static void Main(string[] args)
        {
            string password = "123456";
            string userInput;
            int tryCount = 3;

            while (tryCount-- > 0)
            {
                Console.Write("Введите пароль: ");
                userInput = Console.ReadLine();

                if (userInput == password)
                {
                    Console.WriteLine("Тайное сообщение");
                    break;
                }

                Console.WriteLine($"Неверный пароль, осталось {tryCount} попыток.");
            }
        }
    }
}