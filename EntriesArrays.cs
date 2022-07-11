using System;

namespace CSLight
{
    class EntriesArrays
    {
        static void Main(string[] args)
        {
            string[] entrySurname = new string[0];
            string[] entryOccupation = new string[0];
            
            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine($"Выберите действие: \n[1] - Добавить досье;\n" +
                                  $"[2] - Показать все досье;\n[3] - Удалить досье;\n" +
                                  $"[4] - Поиск по фамилии;\n[5] - Выход;\n");
                
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddEntry(ref entrySurname, ref entryOccupation);
                        break;
                    case "2":
                        ShowAllEntries(ref entrySurname, ref entryOccupation);
                        break;
                    case "3":
                        RemoveEntry(ref entrySurname, ref entryOccupation);
                        break;
                    case "4":
                        SearchForEntry(ref entrySurname, ref entryOccupation);
                        break;
                    case "5":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда");
                        ClearConsole();
                        break;
                }
            }
        }

        static void AddEntry(ref string[] entrySurname, ref string[] entryOccupation)
        {
            string[] tempSurname = new string[entrySurname.Length + 1];
            string[] tempOccupation = new string[entryOccupation.Length + 1];

            for (int i = 0; i < entrySurname.Length; i++)
            {
                tempSurname[i] = entrySurname[i];
                tempOccupation[i] = entryOccupation[i];
            }

            entrySurname = tempSurname;
            entryOccupation = tempOccupation;

            Console.Write("Введите фамилию имя отчество через пробел: ");
            entrySurname[entrySurname.Length - 1] = Console.ReadLine();
            Console.WriteLine("ФИО записано.\n");
            
            Console.Write("Введите должность: ");
            entryOccupation[entryOccupation.Length - 1] = Console.ReadLine();
            Console.WriteLine("Должность записана.\n");

            Console.WriteLine("Досье записано.");
            ClearConsole();
        }

        static void ShowAllEntries(ref string[] entrySurname, ref string[] entryOccupation)
        {
            if (entrySurname.Length == 0)
            {
                Console.WriteLine("Список досье пуст.");
            }
            else
            {
                Console.WriteLine("Просмотр Досье: ");
                for (int i = 0; i < entrySurname.Length; i++)
                {
                    Console.WriteLine($"{i+1}) {entrySurname[i]} - {entryOccupation[i]}");
                }
            }
            ClearConsole();
        }

        static void RemoveEntry(ref string[] entrySurname, ref string[] entryOccupation)
        {
            if (entrySurname.Length == 0)
            {
                Console.WriteLine("Список досье пуст.");
            }
            else
            {
                string[] tempSurname = new string[entrySurname.Length - 1];
                string[] tempOccupation = new string[entryOccupation.Length - 1];

                Console.Write("Введите номер досье которое хотите удалить: ");
                int entryIndex = Convert.ToInt32(Console.ReadLine());
                
                if (entryIndex > entrySurname.Length || entryIndex < 1)
                {
                    Console.WriteLine($"Досье с номером {entryIndex} не существует.");
                    ClearConsole();
                    return;
                }

                for (int i = 0; i < tempSurname.Length; i++)
                {
                    if (i == entryIndex - 1)
                    {
                        continue;
                    }
                    
                    tempSurname[i] = entrySurname[i];
                    tempOccupation[i] = entryOccupation[i];
                }

                entrySurname = tempSurname;
                entryOccupation = tempOccupation;

                Console.WriteLine("Досье было удалено.");
            }
            
            ClearConsole();
        }

        static void SearchForEntry(ref string[] entrySurname, ref string[] entryOccupation)
        {
            Console.Write("Введите фамилию для поиска досье: ");
            string userInput = Console.ReadLine();

            for (int i = 0; i < entrySurname.Length; i++)
            {
                string surname = entrySurname[i].Split(' ')[0];
                
                if (surname.ToLower() == userInput.ToLower())
                {
                    Console.WriteLine($"{entrySurname[i]} - {entryOccupation[i]}");
                    ClearConsole();
                    return;
                }
            }
            
            Console.WriteLine("Досье не найдено.");
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