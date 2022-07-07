using System;

namespace CSLight
{
    class CurrencyConverter
    {
        static void Main(string[] args)
        {
            bool isExitConditionMet = false;
            
            float rubles = 500;
            float dollars = 15;
            float euros = 10;

            float rublesToEuro = 64;
            float rublesToDollars = 63;
            float dollarsToRubles = 0.016f;
            float dollarsToEuro = 0.98f;
            float eurosToRubles = 0.016f;
            float eurosToDollars = 1.02f;

            string userInput;
            float currencyCount;

            while (isExitConditionMet == false)
            {
                Console.WriteLine($"Ваш баланс: {rubles} рублей, {dollars} долларов и {euros} евро.");
                Console.WriteLine("Чтобы перевести рубли в доллары нажмите 1");
                Console.WriteLine("Чтобы перевести рубли в евро нажмите 2");
                Console.WriteLine("Чтобы перевести доллары в рубли нажмите 3");
                Console.WriteLine("Чтобы перевести доллары в евро нажмите 4");
                Console.WriteLine("Чтобы перевести евро в рубли нажмите 5");
                Console.WriteLine("Чтобы перевести евро в доллары нажмите 6");
                Console.WriteLine("Для выхода из программы напишите exit");

                userInput = Console.ReadLine();
                
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Обмен рублей на доллары.");
                        Console.WriteLine("Сколько рублей вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        
                        if (rubles >= currencyCount)
                        {
                            rubles -= currencyCount;
                            dollars += currencyCount / rublesToDollars;
                        }
                        
                        break;
                    case "2":
                        Console.WriteLine("Обмен рублей на евро.");
                        Console.WriteLine("Сколько рублей вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        
                        if (rubles >= currencyCount)
                        {
                            rubles -= currencyCount;
                            euros += currencyCount / rublesToEuro;
                        }
                        
                        break;
                    case "3":
                        Console.WriteLine("Обмен долларов на рубли.");
                        Console.WriteLine("Сколько долларов вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        
                        if (dollars >= currencyCount)
                        {
                            dollars -= currencyCount;
                            rubles += currencyCount / dollarsToRubles;
                        }
                        
                        break;
                    case "4":
                        Console.WriteLine("Обмен долларов на евро.");
                        Console.WriteLine("Сколько долларов вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        
                        if (dollars >= currencyCount)
                        {
                            dollars -= currencyCount;
                            euros += currencyCount / dollarsToEuro;
                        }
                        
                        break;
                    case "5":
                        Console.WriteLine("Обмен евро на рубли.");
                        Console.WriteLine("Сколько евро вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        
                        if (euros >= currencyCount)
                        {
                            euros -= currencyCount;
                            rubles += currencyCount / eurosToRubles;
                        }
                        
                        break;
                    case "6":
                        Console.WriteLine("Обмен евро на доллары.");
                        Console.WriteLine("Сколько евро вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        
                        if (euros >= currencyCount)
                        {
                            euros -= currencyCount;
                            dollars += currencyCount / eurosToDollars;
                        }
                        
                        break;
                    case "exit":
                        isExitConditionMet = true;
                        break;
                    default:
                        Console.WriteLine("Нераспознанная операция.");
                        break;
                }  
            }
        }
    }
}
