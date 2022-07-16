using System;
using System.Collections.Generic;

namespace CSLight
{
    class PurchaseQueue
    {
        static void Main(string[] args)
        {
            int moneyCount = 0;
            Queue<int> clientsPurchases = FillClientsQueue();

            while (clientsPurchases.Count > 0)
            {
                Purchase(clientsPurchases, ref moneyCount);
            }

            Console.WriteLine("Все клиенты обслужены.");
        }

        static Queue<int> FillClientsQueue()
        {
            Random random = new Random();
            
            int minPurchasePrice = 100;
            int maxPurchasePrice = 1000;

            int minQueueLength = 10;
            int maxQueueLength = 20;
            
            int randomQueueLength = random.Next(minQueueLength, maxQueueLength);
            Queue<int> tempQueue = new Queue<int>(randomQueueLength);

            for (int i = 0; i < randomQueueLength; i++)
            {
                tempQueue.Enqueue(random.Next(minPurchasePrice, maxPurchasePrice));
            }

            return tempQueue;
        }

        static void Purchase(Queue<int> clientsPurchases, ref int moneyCount)
        {
            Console.WriteLine($"В очереди находятся {clientsPurchases.Count} клиентов.");
            Console.WriteLine($"В кассе {moneyCount} денег.");
            Console.WriteLine($"Нажмите любую клавишу чтобы совершить покупку на сумму {clientsPurchases.Peek()}");
            Console.ReadKey();
            moneyCount += clientsPurchases.Dequeue();
            Console.Clear();
        }
    }
}
