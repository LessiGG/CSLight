using System;

namespace CSLight
{
    class SymbolsRectangle
    {
        static void Main(string[] args)
        {
            char rectangleSymbol;
            string userName;
            string symbolsString = "";
            int cornerSymbols = 2;

            Console.Write("Введите ваше имя: ");
            userName = Console.ReadLine();

            Console.Write("Введите символ: ");
            rectangleSymbol = Convert.ToChar(Console.ReadLine());

            for (int i = 0; i < userName.Length + cornerSymbols; i++)
            {
                symbolsString += rectangleSymbol;
            }

            Console.WriteLine(symbolsString + "\n" +
                              rectangleSymbol + userName + rectangleSymbol +
                              "\n" + symbolsString);
        }
    }
}
