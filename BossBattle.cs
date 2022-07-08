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
            int playerMaxHelth = 300;
            int playerHalfHealth = playerMaxHelth / 2;

            int desperateBlowDamage = 200;
            int bloodBatDamage = 300;
            int bloodBatCost = 100;
            int divineRestoreHealth = 250;

            int divineUsages = 1;
            int poisonShotPercent = 10;
            bool isSpellChosen = false;

            int userInput;

            while (bossHealth > 0 && playerHealth > 0)
            {
                int poisonShotDamage = bossHealth / 100 * poisonShotPercent;
                
                Console.WriteLine($"Здоровье босса {bossHealth}");
                Console.WriteLine($"Здоровье игрока {playerHealth}");
                
                Console.WriteLine("Выберите заклинание!");
                Console.WriteLine($"1. Призыв кровавого нетопыря (урон - {bloodBatDamage}, стоимость {bloodBatCost} очков здоровья)");
                Console.WriteLine($"2. Отчаянный удар (урон - {desperateBlowDamage}, условие: меньше {playerHalfHealth} здоровья)");
                Console.WriteLine($"3. Длань восстановления (восстановление {divineRestoreHealth}, условие: {divineUsages} раз за битву)");
                Console.WriteLine($"4. Ядовитый плевок (урон - {poisonShotPercent}% от текущего хп босса)");

                userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        
                        if (playerHealth <= bloodBatCost)
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
                        
                        if (playerHealth > playerHalfHealth)
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

                        if (divineUsages == 0)
                        {
                            Console.WriteLine("У вас не осталось дланей на этот бой!");
                        }
                        else
                        {
                            isSpellChosen = true;
                            divineUsages--;
                            playerHealth += divineRestoreHealth;
                        }
                        
                        break;
                    case 4:
                        isSpellChosen = true;
                        bossHealth -= poisonShotDamage;
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
