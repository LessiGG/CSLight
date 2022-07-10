using System;

namespace CSLight
{
    class StringSplit
    {
        static void Main(string[] args)
        {
            string message = "Дана строка с текстом, используя метод строки String.Split() получить массив слов, которые разделены пробелом в тексте и вывести массив, каждое слово с новой строки.";

            string[] messageWords = message.Split(' ');

            for (int i = 0; i < messageWords.Length; i++)
            {
                Console.WriteLine(messageWords[i] + " ");
            }
        }
    }
}