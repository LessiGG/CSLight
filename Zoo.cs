using System;
using System.Collections.Generic;

namespace CSLight
{
    static class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.StartExcursion();
        }
    }

    class Animal
    {
        private static readonly Random _random = new Random();
        
        public string Type { get; private set; }
        public string Gender { get; private set; }
        public string Sound { get; private set; }

        public Animal(string type, string sound)
        {
            Type = type;
            Sound = sound;
            Gender = GetGender();
        }

        private string GetGender()
        {
            int gendersCount = 2;
            int gender = _random.Next(gendersCount);

            return gender == 0 ? "Самец" : "Самка";
        }
    }

    class Aviary
    {
        private static readonly Random _random = new Random();
        private readonly List<Animal> _animals;
        private readonly Animal[] _animalsTypes =
        {
            new Animal("Кошка", "Мяу"),
            new Animal("Собака", "Гав"),
            new Animal("Курица", "Ку-ка-ре-ку"),
            new Animal("Корова", "Му")
        };
        
        private int GetCapacity()
        {
            int minCapacity = 3;
            int maxCapacity = 10;

            return _random.Next(minCapacity, maxCapacity);
        }

        public Aviary()
        {
            int capacity = GetCapacity();
            _animals = new List<Animal>(capacity);
            
            for (var i = 0; i < _animals.Capacity; i++)
            {
                int animalType = _random.Next(_animalsTypes.Length);
                _animals.Add(_animalsTypes[animalType]);
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Всего в вольере {_animals.Count} животных.\nЖивотные в вольере: ");
            foreach (var animal in _animals)
            {
                Console.WriteLine($"Тип: {animal.Type}, вы слышите звук <<{animal.Sound}>>, пол животного {animal.Gender}");
            }
        }
    }

    class Zoo
    {
        private readonly List<Aviary> _aviaries = new List<Aviary>();
        
        public void StartExcursion()
        {
            int aviariesCount = 6;
            CreateAviary(aviariesCount);
            bool isOpen = true;
            Console.WriteLine("Добро пожаловать в зоопарк.\n");
            
            while (isOpen)
            {
                Console.WriteLine("[1] Посмотреть вольер. [2] Выход из зоопарка.");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAviary();
                        break;
                    case "2":
                        isOpen = false;
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда.");
                        break;
                }
            }
        }
        private void ShowAviary()
        {
            Console.WriteLine($"К какому вольеру вы хотите подойти? (Укажите номер вольера, от 1 до {_aviaries.Count})");
            bool isNumber = int.TryParse(Console.ReadLine(), out int numberAviary);

            if (isNumber == false)
            {
                Console.WriteLine("Введите число!");
            }
            else if (numberAviary > 0 && numberAviary <= _aviaries.Count)
            {
                _aviaries[numberAviary - 1].ShowInfo();
            }
            else
            {
                Console.WriteLine("Такого вольера нет в нашем зоопарке");
            }
        }

        private void CreateAviary(int numberAviary)
        {
            for (int i = 0; i < numberAviary; i++)
            {
                _aviaries.Add(new Aviary());
            }
        }
    }
}