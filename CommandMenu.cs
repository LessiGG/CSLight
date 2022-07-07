using System;

namespace CSLight
{
    class CommandMenu
    {
        static void Main(string[] args)
        {
            string userInput;
            bool isExitConditionMet = false;

            string userName = "";
            string consoleColor = "";
            string password = "";

            while (!isExitConditionMet)
            {
                Console.WriteLine("Введите команду из списка:");
                Console.WriteLine("SetName – установить имя");
                Console.WriteLine("ChangeConsoleColor - изменить цвет консоли");
                Console.WriteLine("SetPassword – установить пароль");
                Console.WriteLine("WriteName – вывести имя (после ввода пароля)");
                Console.WriteLine("Esc – выход из программы.");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "SetName":
                        Console.Write("Введите ваше имя: ");
                        userName = Console.ReadLine();
                        break;
                    case "ChangeConsoleColor":
                        Console.WriteLine("Введите желаемый цвет (на английском)");
                        consoleColor = Console.ReadLine();
                        switch (consoleColor)
                        {
                            case "red":
                                Console.BackgroundColor = ConsoleColor.Red;
                                break;
                            case "green":
                                Console.BackgroundColor = ConsoleColor.Green;
                                break;
                            case "blue":
                                Console.BackgroundColor = ConsoleColor.Blue;
                                break;
                            case "yellow":
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                break;
                            default:
                                Console.WriteLine("Я не знаю такой цвет.");
                                break;
                        }
                        break;
                    case "SetPassword":
                        Console.Write("Введите пароль: ");
                        password = Console.ReadLine();
                        break;
                    case "WriteName":
                        if (userName == "")
                            Console.WriteLine("Сначала задайте имя!");
                        else if (password == "")
                            Console.WriteLine("Сначала задайте пароль!");
                        else
                        {
                            Console.Write("Для вывода имени введите пароль: ");
                            userInput = Console.ReadLine();
                        }

                        if (userInput == password)
                            Console.WriteLine(userName);
                        else
                            Console.WriteLine("Пароль неправильный!");
                        break;
                    case "Esc":
                        isExitConditionMet = true;
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда.");
                        break;
                }
            }
        }
    }
}