using System;
using System.Collections.Generic;

namespace CSLight
{
    class TrainPlanMaker
    {
        static void Main(string[] args)
        {
            TrainStation station = new TrainStation();
            bool isStationWorking = true;

            while (isStationWorking)
            {
                station.UpdateDirectionsView();
                
                Console.WriteLine("[1] Создать направление [2] Выход из программы.");
                string userInput = Console.ReadLine();
                
                switch (userInput)
                {
                    case "1":
                        station.PerformStationWork();
                        break;
                    case "2":
                        isStationWorking = false;
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда.");
                        break;
                }                            
            }
        }
    }

    class TrainStation
    {
        private readonly Random _random = new Random();
        private readonly Dictionary<string, string> _directions = new Dictionary<string, string>();

        private int _totalPassengersCount;
        private int _departurePlatform;

        public TrainStation()
        {
            _totalPassengersCount = SellTickets();
            _departurePlatform = ChooseDeparturePlatform();
        }
        
        public void PerformStationWork()
        {
            if (TryCreateDirection() == true)
            {
                CreateTrain(_totalPassengersCount);
                PressToContinue();
                UpdateDirectionsView();
            }
            else
            {
                PressToContinue();
            }
        }

        private void PressToContinue()
        {
            Console.WriteLine("Введите любую клавишу чтобы продолжить работу...");
            Console.ReadLine();
            Console.Clear();
        }

        private void ShowDirecions()
        {
            Console.WriteLine("Табло отправлений поезда:");

            if (_directions.Count > 0)
            {
                foreach (var direction in _directions)
                {
                    Console.WriteLine($"Поезд по направлению {direction.Key} - {direction.Value}\n" +
                                      $"Количество пассажиров: {_totalPassengersCount}\nОтправляется с пути номер {_departurePlatform}\n");
                }
            }
            else
            {
                Console.WriteLine("Никаких отправлений пока не назначено.");
            }
        }
        
        public void UpdateDirectionsView()
        {
            Console.SetCursorPosition(0, 0);
            ShowDirecions();
            Console.SetCursorPosition(0, 10);
        }

        private bool TryCreateDirection()
        {
            Console.WriteLine("Введите город отбытия: ");
            string departure = GetUserString();
            
            Console.WriteLine("Введите город прибытия: ");
            string destination = GetUserString();
            
            if (departure == null || destination == null)
            {
                Console.WriteLine("Введены некоректные данные.");
                return false;
            }
            
            if (_directions.ContainsKey(departure))
            {
                Console.WriteLine("Поезд из этого города уже забронирован.");
                return false;
            }

            Console.WriteLine($"Направление {departure} - {destination} успешно создано.");
            _directions.Add(departure, destination);
            return true;
        }

        private int SellTickets()
        {
            int minPassengersCount = 20;
            int maxPassengersCount = 50;
            
            _totalPassengersCount = _random.Next(minPassengersCount, maxPassengersCount);
            return _totalPassengersCount;
        }

        private void CreateTrain(int passengersCount)
        {
            Train train = new Train();

            while (passengersCount > train.TrainCapacity)
            {
                train.AddCar();
            }
        }
        
        private int ChooseDeparturePlatform()
        {
            int minPlatformsCount = 1;
            int maxPlatformCount = 5;
            
            int depaturePlatform = _random.Next(minPlatformsCount, maxPlatformCount + 1);
            return depaturePlatform;
        }
        
        private string GetUserString()
        {
            string text = Console.ReadLine();
            return text;
        }
    }

    class Train
    {
        private Random _random = new Random();

        private int _carsCount;
        private int _carsCapacity;

        public int TrainCapacity => _carsCapacity * _carsCount;

        public Train()
        {
            _carsCount = GetCarsCount();
            _carsCapacity = GetCarsCapacity();
        }

        public void AddCar()
        {
            _carsCount++;
        }

        private int GetCarsCapacity()
        {
            int minCarsCapacity = 10;
            int maxCarsCapacity = 20;
            
            _carsCapacity = _random.Next(minCarsCapacity, maxCarsCapacity + 1);
            return _carsCapacity;
        }

        private int GetCarsCount()
        {
            int minCarsCpunt = 1;
            int MaxCarsCount = 5;
            
            _carsCount = _random.Next(minCarsCpunt, MaxCarsCount + 1);
            return _carsCount;
        }
    }
}