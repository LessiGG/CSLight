using System;

namespace CSLight
{
    class SymbolsRectangle
    {
        static void Main(string[] args)
        {
            char rectangleSymbol;
            string userName;
            int cornerSymbols = 2;

            Console.Write("Введите ваше имя: ");
            userName = Console.ReadLine();

            Console.Write("Введите символ: ");
            rectangleSymbol = Convert.ToChar(Console.ReadLine());

            for (int i = 0; i < userName.Length + cornerSymbols; i++)
            {
                Console.Write(rectangleSymbol);
            }

            Console.WriteLine($"\n{rectangleSymbol}{userName}{rectangleSymbol}");
            
            for (int i = 0; i < userName.Length + 2; i++)
            {
                Console.Write(rectangleSymbol);
            }
        }
    }
}