using System;
using System.Collections.Generic;

namespace CSLight
{
    class Library
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("[1] Посмотреть все книги в библиотеке\n[2] Добавить книгу\n[3] Удалить книгу\n[4] Найти книги по параметрам\n[5] Выход");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        storage.ShowAllBooks();
                        break;
                    case "2":
                        storage.AddBook();
                        break;
                    case "3":
                        storage.RemoveBook();
                        break;
                    case "4":
                        storage.FindBook();
                        break;
                    case "5":
                        isWorking = false;
                        break;
                }
            }
        }

        class Book
        {
            public string Title { get; }
            public string Author { get; }
            public int ReleaseYear { get; }

            public Book(string title, string author, int releaseYear)
            {
                Title = title;
                Author = author;
                ReleaseYear = releaseYear;
            }
        }

        class Storage
        {
            private readonly List<Book> _books = new List<Book>();
            private readonly List<Book> _foundBooks = new List<Book>();

            public Storage()
            {
                _books.Add(new Book("Оно", "Стивен Кинг", 1986));
                _books.Add(new Book("Стальная крыса", "Гарри Гаррисон", 1961));
                _books.Add(new Book("Телефон мистера Харригана", "Стивен Кинг", 2020));
                _books.Add(new Book("Гарри Поттер и философский камень", "Харпер Ли", 1997));
            }

            public void AddBook()
            {
                Console.WriteLine("Введите название книги");
                string title = GetUserString();
                
                Console.WriteLine("Введите имя и фамилию автора");
                string author = GetUserString();
                
                Console.WriteLine("Введите год выпуска");
                int releaseYear = GetUserInt();

                if (title == null && author == null)
                {
                    Console.WriteLine("Введите корректные данные");
                }
                else
                {
                    _books.Add(new Book(title, author, releaseYear));
                    
                    Console.WriteLine($"Книга {title} добавлена в библиотеку");
                }
            }

            public void RemoveBook()
            {
                Console.WriteLine("Введите номер книги которую хотите удалить: ");

                if (TryGetBook(out Book book))
                {
                    _books.Remove(book);
                }
            }

            public void ShowAllBooks()
            {
                Console.WriteLine("Список книг: ");

                foreach (var book in _books)
                {
                    Console.WriteLine($"Книга - {book.Title}. Автор - {book.Author}. Год выпуска - {book.ReleaseYear}");
                }
            }

            public void FindBook()
            {
                Console.WriteLine("[1] Найти книгу по названию. [2] Найти книгу по автору. [3] Найти книгу по году выпуска");
                string userInput = GetUserString();

                switch (userInput)
                {
                    case "1":
                        FindByTitle();
                        break;
                    case "2":
                        FindByAuthor();
                        break;
                    case "3":
                        FindByYear();
                        break;
                }
            }

            private bool TryGetBook(out Book book)
            {
                int userInput = GetUserInt();

                if (userInput > 0 && userInput - 1 < _books.Count)
                {
                    book = _books[userInput - 1];
                    return true;
                }

                book = null;
                Console.WriteLine($"Книги под номером {userInput} не существует");
                return false;
            }

            private void ShowFoundBooks()
            {
                if (_foundBooks.Count > 0)
                {
                    Console.WriteLine("Книги по вашему запросу: ");
                    foreach (var foundBook in _foundBooks)
                    {
                        Console.WriteLine($"Книга - {foundBook.Title}. Автор - {foundBook.Author}. Год выпуска - {foundBook.ReleaseYear}");           
                    }                
                }
                else
                {
                    Console.WriteLine($"В библиотеке нет таких книг");
                }
                
                _foundBooks.Clear();
            }

            private void FindByYear()
            {
                Console.WriteLine("Введите год выпуска книги: ");
                int year = GetUserInt();

                foreach (var book in _books)
                {
                    if (year == book.ReleaseYear)
                    {
                        _foundBooks.Add(book);
                    }                
                }
                
                ShowFoundBooks();
            }

            private void FindByAuthor()
            {
                Console.Write("Введите имя и фамилию автора: ");
                string author = GetUserString();
            
                foreach (var book in _books)
                {
                    if (author.ToLower() == book.Author.ToLower())
                    {
                        _foundBooks.Add(book);
                    }                
                }
                
                ShowFoundBooks();
            }

            private void FindByTitle()
            {
                Console.WriteLine("Введите название книги: ");
                string title = GetUserString();

                foreach (var book in _books)
                {
                    if (title.ToLower() == book.Title.ToLower())
                    {
                        _foundBooks.Add(book);
                    }                
                }
                
                ShowFoundBooks();
            }
            
            private string GetUserString()
            {
                string userInput = Console.ReadLine();
                return userInput;
            }

            private int GetUserInt()
            {
                bool isNumber = int.TryParse(Console.ReadLine(), out int number);

                if (isNumber == false)
                {
                    Console.WriteLine("Введите число.");
                }

                return number;
            }
        }
    }
}
