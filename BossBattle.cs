using System;

namespace CSLight
{
    class BossBattle
    {
        static void Main(string[] args)
        {
            int bossHealth = 1000;
            int bossDamage = 50;

            int playerHealth = 300;
            int playermaxHelth = 300;

            int desperateBlowDamage = 200;
            int bloodBatDamage = 300;
            int bloodBatCost = 100;
            int divineRestoreHealth = 250;

            bool isDivineUsed = false;
            bool isSpellChosen = false;

            int userInput;

            while (bossHealth > 0 && playerHealth > 0)
            {
                int poisonShot = bossHealth / 100 * 10;
                
                Console.WriteLine($"Здоровье босса {bossHealth}");
                Console.WriteLine($"Здоровье игрока {playerHealth}");
                
                Console.WriteLine("Выберите заклинание!");
                Console.WriteLine("1. Призыв кровавого нетопыря (урон - 300, стоимость 100 очков здоровья)");
                Console.WriteLine("2. Отчаянный удар (урон - 200, условие: меньше 50% здоровья)");
                Console.WriteLine("3. Длань восстановления (восстановление 250, условие: 1 раз за битву)");
                Console.WriteLine("4. Ядовитый плевок (урон - 10% от текущего хп босса)");

                userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        
                        if (playerHealth <= 200)
                        {
                            Console.WriteLine("Невозможно применить заклинание, так как оно вас убьет.");
                        }
                        else
                        {
                            isSpellChosen = true;
                            playerHealth -= bloodBatCost;
                            bossHealth -= bloodBatDamage;
                        }
                        
                        break;
                    case 2:
                        
                        if (playerHealth > playermaxHelth / 2)
                        {
                            Console.WriteLine("У вас слишком много здоровья для этой атаки!");
                        }
                        else
                        {
                            isSpellChosen = true;
                            bossHealth -= desperateBlowDamage;
                        }
                        
                        break;
                    case 3:

                        if (isDivineUsed == true)
                        {
                            Console.WriteLine("Вы уже использовали длань в этом бою!");
                        }
                        else
                        {
                            isSpellChosen = true;
                            isDivineUsed = true;
                            playerHealth += divineRestoreHealth;
                        }
                        
                        break;
                    case 4:
                        isSpellChosen = true;
                        bossHealth -= poisonShot;
                        break;
                    default:
                        Console.WriteLine("Я не знаю такого заклинания.");
                        break;
                }

                if (isSpellChosen == true)
                {
                    playerHealth -= bossDamage;
                }

                isSpellChosen = false;
            }
            
            if (bossHealth <= 0 && playerHealth <= 0)
            {
                Console.WriteLine("Ничья. И герой, и босс пали.");
            }
                
            else if (bossHealth <= 0)
            {
                Console.WriteLine("Победа. Игрок победил.");
            }
                
            else if (playerHealth <= 0)
            {
                Console.WriteLine("Поражение. Босс победил.");
            }
        }
    }
}