using System;
using System.Collections.Generic;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoService autoAutoService = new AutoService();
            autoAutoService.CreateQueue();
            autoAutoService.StartWork();            
        }
    }
    
    class AutoService
    {
        private readonly Random _random = new Random();
        private readonly Queue<Client> _clients = new Queue<Client>();
        private readonly Warehouse _warehouse = new Warehouse();

        private int _repairCost = 200;
        private int _repairPenalty = 300;
        private int _moneyCount = 1000;

        public void StartWork()
        {
            bool isWorking = true;

            while (isWorking && _clients.Count > 0)
            {
                _warehouse.ShowInfo();
                Console.WriteLine($"\nНа балансе автосервиса {_moneyCount}");
                Console.WriteLine($"В очереди на обслуживание {_clients.Count} машин(ы).\n[1] Начать техосмотр [2] Завершить работу");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ServeClient();
                        break;
                    case "2":
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Неизвестная операция.");
                        break;
                }
            }
        }

        public void CreateQueue()
        {
            int minNumberClient = 2;
            int maxNumberClient = 10;
            int clientsCount = _random.Next(minNumberClient, maxNumberClient);

            for (int i = 0; i < clientsCount; i++)
            {
                _clients.Enqueue(new Client());
            }
        }

        private bool TryRepairCar(Client client)
        {
            Console.WriteLine("Введите номер детали для замены");
            bool isNumber = int.TryParse(Console.ReadLine(), out int detailId);

            if (isNumber == false)
            {
                Console.WriteLine("Введите число!");
                return false;
            }
            
            if (detailId > 0 && detailId - 1 <= _warehouse.GetWarehouseDetails().Count && client.BrokenDetail.Name == _warehouse.GetWarehouseDetails()[detailId - 1].Detail.Name)
            {
                int detailToChange = detailId - 1;

                if (_warehouse.GetWarehouseDetails()[detailToChange].Amount > 1)
                {
                    _warehouse.GetWarehouseDetails()[detailToChange].ReduceAmount();
                }
                else
                {
                    _warehouse.GetWarehouseDetails().RemoveAt(detailToChange);
                }
                
                return true;
            }
            
            if (detailId > 0 && detailId - 1 <= _warehouse.GetWarehouseDetails().Count && client.BrokenDetail.Name != _warehouse.GetWarehouseDetails()[detailId - 1].Detail.Name)
            {
                Console.WriteLine("Механик ошибся, сервис должен выплатить штраф!");
                AssignPenalty();
                return false;
            }
            
            Console.WriteLine("Такой детали нет на складе.");
            return false;
        }        

        private int GetRepairPrice(Client client)
        {
            int repairPrice = 0;

            for (int i = 0; i < _warehouse.GetWarehouseDetails().Count; i++)
            {
                if (client.BrokenDetail.Name == _warehouse.GetWarehouseDetails()[i].Detail.Name)
                {
                    repairPrice += _warehouse.GetWarehouseDetails()[i].Detail.Price + _repairCost;
                    break;
                }
            }            
            return repairPrice;
        }                

        private void ShowBreackdown(Client client)
        {
            Console.WriteLine($"Требуется замена детали: {client.BrokenDetail.Name}");
        }        

        private void ServeClient()
        {
            Client client = _clients.Dequeue();
            ShowBreackdown(client);
            
            Console.WriteLine("\nВыберите дальнейшие действия:\n[1] Устранить поломку\n[2] Отказать в обслуживании");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    RepairCar(client);
                    break;
                case "2":
                    AssignPenalty();
                    break;
                default:
                    Console.WriteLine("Неизвестная операция, вы так долго мешкались что клиент ушел недовольный.");
                    break;
            }
        }
        
        private void RepairCar(Client client)
        {
            if (TryRepairCar(client))
            {
                int repairPrice = GetRepairPrice(client);
                Console.WriteLine($"Автомобиль отремонтирован, сервис заработал {repairPrice}");
                _moneyCount += repairPrice;
            }
        }

        private void AssignPenalty()
        {
            Console.WriteLine($"Сервиc не смог устранить неисправность - штраф {_repairPenalty}");
            _moneyCount -= _repairPenalty;
        }
    }


    class Client
    {
        private readonly DetailsTypes _details = new DetailsTypes();
        public Detail BrokenDetail { get; private set; }

        public Client()
        {
            IdentifyBreackdown();
        }

        private void IdentifyBreackdown()
        {
            BrokenDetail = _details.GetRandomDetail();
        }
        
    }

    class DetailsTypes
    {
        private static readonly Random _random = new Random();
        private readonly List<Detail> _details = new List<Detail>();

        public DetailsTypes()
        {
            _details.Add(new Detail("Бампер", 250));
            _details.Add(new Detail("Фара", 50));
            _details.Add(new Detail("Бензобак", 500));
            _details.Add(new Detail("Руль", 150));
            _details.Add(new Detail("багажник", 200));
            _details.Add(new Detail("Колесо", 100));
            _details.Add(new Detail("Капот", 150));
        }

        public List<Detail> GetDetails()
        {
            List<Detail> warehouseDetails = new List<Detail>();

            foreach (var detail in _details)
            {
                warehouseDetails.Add(detail);
            }
            
            return warehouseDetails;
        }

        public Detail GetRandomDetail()
        {
            int detailId = _random.Next(0, _details.Count);
            Detail brokenDetail = _details[detailId];
            
            return brokenDetail;
        }
    }
  
    class Warehouse
    {
        private static readonly Random _random = new Random();
        private readonly List<WarehouseCell> _details = new List<WarehouseCell>();
        private readonly DetailsTypes _detailsTypes = new DetailsTypes();
        
        public Warehouse()
        {
            FillWarehouse();
        }

        public void ShowInfo()
        {
            Console.WriteLine("Запчасти на складе:");
            for (int i = 0; i < _details.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_details[i].Detail.Name} Цена: {_details[i].Detail.Price} Количество: {_details[i].Amount}");
            }
        }        

        public List<WarehouseCell> GetWarehouseDetails()
        {
            List<WarehouseCell> warehouseDetails = new List<WarehouseCell>();

            foreach (var detail in _details)
            {
                warehouseDetails.Add(detail);
            }
            return warehouseDetails;
        }

        private void FillWarehouse()
        {
            int minDetailsAmount = 1;
            int maxDetailsAmount = 5;

            foreach (var detail in _detailsTypes.GetDetails())
            {
                int detailsAmount = _random.Next(minDetailsAmount, maxDetailsAmount);
                _details.Add(new WarehouseCell(detail, detailsAmount));
            }            
        }                
    }

    class WarehouseCell
    {
        public Detail Detail { get; private set; }
        public int Amount { get; private set; }

        public WarehouseCell(Detail detail, int amount)
        {
            Amount = amount;
            Detail = detail;
        }

        public void ReduceAmount()
        {
            Amount--;
        }
    }

    class Detail
    {
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Detail(string name, int price)
        {
            Name = name;
            Price = price;
        }        
    }
}