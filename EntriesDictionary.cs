using System;
using System.Collections.Generic;

namespace CSLight
{
    class EntriesDictionary
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> entries = new Dictionary<string, string>();

            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine($"Выберите действие: \n[1] - Добавить досье;\n" +
                                  $"[2] - Показать все досье;\n[3] - Удалить досье;\n" +
                                  $"[4] - Выход;");
                
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddEntry(entries);
                        break;
                    case "2":
                        ShowAllEntries(entries);
                        break;
                    case "3":
                        RemoveEntry(entries);
                        break;
                    case "4":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда");
                        ClearConsole();
                        break;
                }
            }
        }

        static void AddEntry(Dictionary<string, string> entries)
        {
            Console.Write("Введите фамилию имя отчество через пробел: ");
            string name = Console.ReadLine();
            
            if (entries.ContainsKey(name))
            {
                Console.WriteLine("Такое имя уже есть.");
            }
            else
            {
                Console.Write("Введите должность: ");
                string ocupation = Console.ReadLine();

                entries.Add(name, ocupation);
                Console.WriteLine("Досье записано.");
            }
            
            ClearConsole();
        }

        static void ShowAllEntries(Dictionary<string, string> entries)
        {
            int index = 1;
            
            foreach (var entry in entries)
            {
                Console.WriteLine($"{index}) {entry.Key} - {entry.Value}");
                index++;
            }
            
            ClearConsole();
        }

        static void RemoveEntry(Dictionary<string, string> entries)
        {
            Console.Write("Введите номер досье которое хотите удалить: ");
            bool gotNumber = int.TryParse(Console.ReadLine(), out int entryIndex);
            
            int index = 1;

            if (gotNumber == true)
            {
                foreach (var entry in entries)
                {
                    if (entryIndex == index)
                    {
                        entries.Remove(entry.Key);
                        break;
                    }
                
                    index++;
                }

                Console.WriteLine("Досье было удалено.");
            }

            else
            {
                Console.WriteLine("Был введен не номер.");
            }

            ClearConsole();
        }

        static void ClearConsole()
        {
            Console.WriteLine("\nНажмите любую клавишу чтобы продолжить...");
            Console.ReadKey();
            Console.Clear();
        }
    }
} 
