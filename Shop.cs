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

    class Cell
    {
        public Product Product { get; private set; }
        public int Count { get; private set; }

        public Cell(Product product, int count)
        {
            Product = product;
            Count = count;
        }

        public void IncreaseCount()
        {
            Count++;
        }
        
        public void DecreaseCount()
        {
            Count--;
        }
    }

    class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set;  }
        public int Price { get; private set; }

        public Product(string name, int price)
        {
            Id++;
            Name = name;
            Price = price;
        }
    }

    class Trader
    {
        protected List<Cell> Cells = new List<Cell>();
        protected int MoneyCount;

        public virtual void ShowProducts()
        {
            Console.WriteLine($"Ваши деньги: {MoneyCount}");

            if (Cells.Count > 0)
            {
                Console.WriteLine("Ваш список товаров: ");
            
                foreach (var cell in Cells)
                {
                    Console.WriteLine($"Товар {cell.Product.Name}, количество {cell.Count}.");
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
            MoneyCount = 100;
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

            if (id > seller.ProductsCount - 1 && id < 0)
            {
                Console.WriteLine($"Нет предмета под номером {id}.");
                return;
            }

            if (MoneyCount > seller.GetCell(id).Product.Price)
            {
                Product productToBuy = seller.SellProduct(id);

                if (Cells.Any(cell => cell.Product.Name.Contains(productToBuy.Name)))
                {
                    Cells[productToBuy.Id - 1].IncreaseCount();
                }
                else
                {
                    Cells.Add(new Cell(productToBuy, 1));
                }

                MoneyCount -= productToBuy.Price;

                Console.WriteLine($"{productToBuy.Name} приобретен(о).");
            }
            else
            {
                Console.WriteLine("Недостаточно денег.");
            }
        }
    }

    class Seller : Trader
    {
        public int ProductsCount => Cells.Count;
        
        public Seller()
        {
            Cells.Add(new Cell(new Product("Колбаса", 40), 8));
            Cells.Add(new Cell(new Product("Сыр", 30), 6));
            Cells.Add(new Cell(new Product("Сметана", 50), 2));
            Cells.Add(new Cell(new Product("Зелень", 15), 5));
        }

        public Cell GetCell(int id) => Cells[id];
        
        public Product SellProduct(int id)
        {
            Cell cell = GetCell(id);
            
            if (cell.Count <= 0)
            {
                Console.WriteLine("Продукта нет на складе.");
            }
            else if (cell.Count == 1)
            {
                Cells.Remove(cell);
            }
            else
            {
                cell.DecreaseCount();
            }
            
            MoneyCount += cell.Product.Price;

            Product productToSell = new Product(cell.Product.Name, cell.Product.Price);
            return productToSell;
        }

        public override void ShowProducts()
        {
            Console.WriteLine($"Баланс магазина: {MoneyCount}");
            Console.WriteLine("Список товаров магазина: ");

            for (var i = 0; i < Cells.Count; i++)
            {
                Console.WriteLine($"{i}) Товар {Cells[i].Product.Name}, количество {Cells[i].Count}, стоимость {Cells[i].Product.Price}.");
            }
        }
    }
}
