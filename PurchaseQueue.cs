using System;
using System.Collections.Generic;

namespace CSLight
{
    class PurchaseQueue
    {
        static void Main(string[] args)
        {
            int moneyCount = 0;
            
            Queue<int> clientsPurchases;
            
            clientsPurchases = FillPurchasesQueue();

            while (clientsPurchases.Count > 0)
            {
                Purchase(clientsPurchases, ref moneyCount);
            }

            Console.WriteLine("Все клиенты ушли с покупками!");
            Console.ReadKey();
        }

        static Queue<int> FillPurchasesQueue()
        {
            Random random = new Random();
            int minPurchasePrice = 100;
            int maxPurchasePrice = 1000;
            int minQueueLength = 10;
            int maxQueueLength = 20;
            
            int randomQueueLength = random.Next(minQueueLength, maxQueueLength);
            Queue<int> tempClientsPurchases = new Queue<int>(randomQueueLength);

            for (int i = 0; i < randomQueueLength; i++)
            {
                tempClientsPurchases.Enqueue(random.Next(minPurchasePrice, maxPurchasePrice));
            }

            return tempClientsPurchases;
        }

        static void Purchase(Queue<int> clientsCash, ref int moneyCount)
        {
            Console.WriteLine($"В очереди - {clientsCash.Count}  клиент(ов)");
            Console.WriteLine($"Сумма в кассе:  {moneyCount}");
            Console.WriteLine($"Нажмите любую клавишу чтобы совершить покупку на сумму: {clientsCash.Peek()}");
            Console.ReadKey();
            moneyCount += clientsCash.Dequeue();
            Console.Clear();
        }
    }
}