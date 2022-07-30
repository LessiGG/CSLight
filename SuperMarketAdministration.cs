using System;
using System.Collections.Generic;

namespace CSLight
{
    static class SuperMarketAdministration
    {
        static void Main(string[] args)
        {
            SuperMarket superMarket = new SuperMarket();
            superMarket.CreateClientsQueue();
            superMarket.DisplayClientsCount();

            while (superMarket.ClientsCount > 0)
            {
                superMarket.DisplayClientsCount();
                superMarket.DequeueClient();
            }

            Console.Clear();
            Console.WriteLine("\nВсе клиенты были обслужены.");
        }
    }

    class SuperMarket
    {
        private readonly Random _random = new Random();
        private readonly Queue<Client> _clients = new Queue<Client>();
        private readonly Product[] _products =
        {
            new Product("Колбаса", 50), 
            new Product("Сыр", 30), 
            new Product("Помидоры", 20), 
            new Product("Огурцы", 25), 
            new Product("Салат", 15), 
        };

        public int ClientsCount => _clients.Count;
        
        public void DequeueClient()
        {
            Client currentClient = _clients.Peek();
            currentClient.Pay();
            _clients.Dequeue();
        }
        
        public void DisplayClientsCount()
        {
            Console.WriteLine($"\nКлиентов В очереди: {ClientsCount}.\nВведите любую клавишу чтобы обслужить клиента.");
            Console.ReadLine();
            Console.Clear();
        }

        public void CreateClientsQueue()
        {
            Random random = new Random();
            
            int minClientsCount = 10;
            int maxClientsCount = 20;
            int clientsCount = random.Next(minClientsCount, maxClientsCount);

            for (int i = 0; i < clientsCount; i++)
            {
                int minMoneyCount = 100;
                int maxMoneyCount = 300;
                int moneyCount = random.Next(minMoneyCount, maxMoneyCount);
                
                Client client = new Client(moneyCount);
                client.FillCart(this);
                _clients.Enqueue(client);
            }
        }

        public Product GetRandomProduct()
        {
            int productId = _random.Next(_products.Length);
            
            return _products[productId];
        }
    }

    class Product
    {
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }

    class Client
    {
        private readonly List<Product> _cart = new List<Product>();
        private readonly Random _random = new Random();
        
        private int _money;

        public Client(int money)
        {
            _money = money;
        }

        public void FillCart(SuperMarket market)
        {
            int minProductsCount = 5;
            int maxProductsCount = 10;
            int productsCount = _random.Next(minProductsCount, maxProductsCount);
            
            for (int i = 0; i < productsCount; i++)
            {
                _cart.Add(market.GetRandomProduct());
            }
        }

        public void Pay()
        {
            ShowCart();
            Console.WriteLine($"\nБаланс клиента: {_money}");
            int totalPrice = CalculatePrice();

            while (totalPrice > _money)
            {
                DisposeRandomProduct();
                totalPrice = CalculatePrice();
            }

            _money -= totalPrice;
            Console.WriteLine("Клиент оплатил покупку и ушел.");
        }

        private int CalculatePrice()
        {
            int totalPrice = 0;
            
            foreach (var product in _cart)
            {
                totalPrice += product.Price;
            }

            Console.WriteLine($"\nОбщая стоимость покупок: {totalPrice}.");
            return totalPrice;
        }

        private void DisposeRandomProduct()
        {
            int productToRemoveId = _random.Next(_cart.Count);
            
            Console.WriteLine($"Продукт {_cart[productToRemoveId].Name} пришлось выложить.");
            _cart.RemoveAt(productToRemoveId);
        }

        private void ShowCart()
        {
            Console.WriteLine("Список продуктов клиента: ");
            
            foreach (var product in _cart)
            {
                Console.Write(product.Name + " ");
            }
        }
    }
}