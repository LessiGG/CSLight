using System;
using System.Collections.Generic;

namespace CSLight
{
    static class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            Aquarium aquarium = new Aquarium();
            

            while (isWorking)
            {
                Console.WriteLine("[1] Показать всех рыбок. [2] Добавить рыбку. [3] Достать рыбку. [4] Выход");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        aquarium.DisplayFish();
                        break;
                    case "2":
                        aquarium.AddFish();
                        break;
                    case "3":
                        aquarium.RemoveFish();
                        break;
                    case "4":
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Неизвестная операция.");
                        break;
                }

                aquarium.UpdateFishAge();
                aquarium.RemoveDeadFish();
            }
        }
    }

    class Fish
    {
        private int _yearOfDeath = 8;
        
        public string Name { get; private set; }
        public int Age { get; private set; }
        public bool IsAlive => Age < _yearOfDeath;

        public Fish(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void IncreaseAge()
        {
            Age++;
        }
    }

    class Aquarium
    {
        private readonly List<Fish> _fish;

        private int _capacity = 5;

        public Aquarium()
        {
            _fish = new List<Fish>();
            _fish.Add(new Fish("Красная рыбка", 3));
            _fish.Add(new Fish("Синяя рыбка", 5));
        }

        public void DisplayFish()
        {
            if (_fish.Count > 1)
            {
                for (var i = 0; i < _fish.Count; i++)
                {
                    Console.WriteLine($"{i+1}) Рыбка {_fish[i].Name}. Возраст: {_fish[i].Age}.");
                }
            }
            else
            {
                Console.WriteLine("В аквариуме пока нет рыбок.");
            }
        }

        public void UpdateFishAge()
        {
            foreach (var fish in _fish)
            {
                fish.IncreaseAge();
            }
        }

        public void RemoveDeadFish()
        {
            for (var i = 0; i < _fish.Count; i++)
            {
                if (_fish[i].IsAlive == false)
                {
                    _fish.Remove(_fish[i]);
                }
            }
        }

        public void AddFish()
        {
            if (_capacity == _fish.Count)
            {
                Console.WriteLine("В аквариуме больше нет места.");
                return;
            }
            
            Console.WriteLine("Введите имя новой рыбки:");
            string name = Console.ReadLine();
            
            Console.WriteLine("Введите возраст рыбки. Рыбка не может быть младше года и старше 8 лет");
            int age = GetUserAge();

            if (age == 0)
            {
                Console.WriteLine("Был введен некорректный возраст.");
            }
            else
            {
                _fish.Add(new Fish(name, age));
            }
        }

        public void RemoveFish()
        {
            if (_fish.Count > 1)
            {
                if (TryGetFish(out Fish fish))
                {
                    _fish.Remove(fish);
                }
            }
            else
            {
                Console.WriteLine("В аквариуме нет рыбок.");
            }
        }

        private bool TryGetFish(out Fish fish)
        { 
            Console.WriteLine("Введите номер рыбки");
            bool inputNumber = int.TryParse(Console.ReadLine(), out int fishNumber);

            if (inputNumber == false)
            {
                Console.WriteLine("Введите номер");
                fish = null;
                return false;
            }
            
            if (fishNumber > 0 && fishNumber - 1 < _fish.Count)
            {
                fish = _fish[fishNumber - 1];
                Console.WriteLine($"Вы вынули {fish.Name} из аквариума");
                return true;
            }
            
            Console.WriteLine("Такой рыбки нет в аквариуме");
            fish = null;
            return false;
        }

        private int GetUserAge()
        {
            int minAge = 1;
            int maxAge = 8;
            bool isNumber = int.TryParse(Console.ReadLine(), out int age);

            if (isNumber == true && age >= minAge && age <= maxAge)
            {
                return age;
            }

            Console.WriteLine("Введите правильный возраст рыбки");
            age = 0;
            return age;
        }
    }
}