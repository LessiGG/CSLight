using System;
using System.Collections.Generic;

namespace CSLight
{
    class Dictionary
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> translations = new Dictionary<string, string>();
            
            translations.Add("Яблоко", "Apple");

            Console.Write("Введите слово чтобы получить его перевод: ");
            string userInput = Console.ReadLine();

            foreach (var translation in translations)
            {
                if (userInput != translation.Key)
                {
                    Console.WriteLine("На это слово нет перевода.");
                }
                else
                {
                    Console.WriteLine(translation.Value);
                }
            }
        }
    }
}