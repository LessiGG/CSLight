using System;
using System.Collections.Generic;
using System.Linq;

namespace CSLight
{
    class Shop
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Seller seller = new Seller();
            bool isWorking = true;
            
            Console.WriteLine("Добро пожаловать в магазин");

            while (isWorking)
            {
                Console.WriteLine("[1] Показать покупки. [2] Показать товары. [3] Купить. [4] Выйти из магазина");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        player.ShowProducts();
                        break;
                    case "2":
                        seller.ShowProducts();
                        break;
                    case "3":
                        player.BuyProduct(seller);
                        break;
                    case "4":
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда.");
                        break;
                }
            }
        }
    }

    class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set;  }
        public int Price { get; private set; }
        public int Count { get; private set; }

        public Product(string name, int price, int count)
        {
            Id++;
            Name = name;
            Price = price;
            Count = count;
        }

        public void DecreaseCount()
        {
            Count--;
        }
        
        public void IncreaseCount()
        {
            Count++;
        }
    }

    class Trader
    {
        protected List<Product> Products = new List<Product>();
        protected int MoneyCount;

        public virtual void ShowProducts()
        {
            Console.WriteLine($"Ваши деньги: {MoneyCount}");

            if (Products.Count > 0)
            {
                Console.WriteLine("Ваш список товаров: ");
            
                foreach (var product in Products)
                {
                    Console.WriteLine($"Товар {product.Name}, количество {product.Count}.");
                }
            }
            else
            {
                Console.WriteLine("У вас нет покупок.");
            }
        }
    }

    class Player : Trader
    {
        public Player()
        {
            MoneyCount = 1000;
        }
        
        public void BuyProduct(Seller seller)
        {
            Console.WriteLine("Что вы хотите купить? (Введите номер товара): ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int id);
            
            if (isNumber == false)
            {
                Console.WriteLine("Введите число.");
                return;
            }

            if (id > seller.GetProductsCount() - 1)
            {
                Console.WriteLine($"Нет предмета под номером {id}.");
                return;
            }
            
            if (HaveEnoughMoney(id, seller))
            {
                Product productToBuy = seller.SellProduct(id);
                
                if (Products.Any(x => x.Name.Contains(productToBuy.Name)))
                {
                    Products[productToBuy.Id - 1].IncreaseCount();
                }
                else
                {
                    Products.Add(productToBuy);
                }
                
                MoneyCount -= productToBuy.Price;
                    
                Console.WriteLine($"{productToBuy.Name} приобретен(о).");
            }
        }

        private bool HaveEnoughMoney(int id, Seller seller)
        {
            if (MoneyCount > seller.GetProduct(id).Price)
            {
                return true;
            }

            return false;
        }
    }

    class Seller : Trader
    {
        public Seller()
        {
            Products.Add(new Product("Колбаса", 40, 8));
            Products.Add(new Product("Сыр", 30, 6));
            Products.Add(new Product("Сметана", 50, 2));
            Products.Add(new Product("Зелень", 15, 5));
        }

        public int GetProductsCount()
        {
            return Products.Count;
        }

        public Product GetProduct(int id)
        {
            if (id < Products.Count)
            {
                return Products[id];
            }

            Console.WriteLine($"Продукта с id {id} не найдено.");
            return null;
        }
        
        public Product SellProduct(int id)
        {
            Product product = GetProduct(id);
            
            if (product.Count <= 0)
            {
                Console.WriteLine("Продукта нет на складе.");
            }
            else if (product.Count == 1)
            {
                Products.Remove(product);
            }
            else
            {
                product.DecreaseCount();
            }
            
            MoneyCount += product.Price;

            Product productToSell = new Product(product.Name, product.Price, 1);
            return productToSell;
        }

        public override void ShowProducts()
        {
            Console.WriteLine($"Баланс магазина: {MoneyCount}");
            Console.WriteLine("Список товаров магазина: ");

            for (var i = 0; i < Products.Count; i++)
            {
                Console.WriteLine($"{i}) Товар {Products[i].Name}, количество {Products[i].Count}, стоимость {Products[i].Price}.");
            }
        }
    }
}
