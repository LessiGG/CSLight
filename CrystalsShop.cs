using System;

namespace CSLight
{
    class CrystalsShop
    {
        static void Main(string[] args)
        {
            int coinsCount;
            int crystalsCount;
            int crystalPrice = 10;
            
            Console.Write("Введите сколько у вас денег: ");
            coinsCount = Convert.ToInt32(Console.ReadLine());
            
            Console.Write($"Введите сколько кристаллов вы хотите приобрести (стоимость одного кристалла {crystalPrice}): ");
            crystalsCount = Convert.ToInt32(Console.ReadLine());

            coinsCount -= crystalPrice * crystalsCount;

            Console.WriteLine($"У вас {crystalsCount} кристаллов и {coinsCount} монет.");
        }
    }
}