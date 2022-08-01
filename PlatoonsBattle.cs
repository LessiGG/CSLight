using System;
using System.Collections.Generic;

namespace CSLight
{
    static class PlatoonsBattle
    {
        static void Main(string[] args)
        {
            BattleField battleField = new BattleField();
            
            battleField.Battle();
            battleField.ShowBattleResults();
            
            Console.ReadLine();
        }
    }

    class BattleField
    {
        private readonly Platoon _leftSidePlatoon = new Platoon();
        private readonly Platoon _rightSidePlatoon = new Platoon();
        
        private Soldier _leftSideSoldier;
        private Soldier _rightSideSoldier;

        public void Battle()
        {
            while (_leftSidePlatoon.GetSoldiersCount() > 0 && _rightSidePlatoon.GetSoldiersCount() > 0)
            {
                Console.WriteLine("Взвод левой стороны: ");
                _leftSidePlatoon.ShowPlatoon();
                Console.WriteLine("Взвод правой стороны: ");
                _rightSidePlatoon.ShowPlatoon();
                
                _leftSideSoldier = _leftSidePlatoon.GetRandomSoldier();
                _rightSideSoldier = _rightSidePlatoon.GetRandomSoldier();
                
                _leftSideSoldier.UseSpecial();
                _rightSideSoldier.UseSpecial();
                
                _leftSideSoldier.TakeDamage(_rightSideSoldier.Damage);
                _rightSideSoldier.TakeDamage(_leftSideSoldier.Damage);
                RemoveDeadSoldier();

                Console.WriteLine("Введите любую клавишу чтобы продолжить бой...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void ShowBattleResults()
        {
            if (_leftSidePlatoon.GetSoldiersCount() <= 0)
            {
                Console.WriteLine("Победила правая сторона.");
            }
            else if (_rightSidePlatoon.GetSoldiersCount() <= 0)
            {
                Console.WriteLine("Победила левая сторона.");
            }
            else
            {
                Console.WriteLine("На поле боя ничья.");
            }
        }

        private void RemoveDeadSoldier()
        {
            if (_leftSideSoldier.Health <= 0)
            {
                _leftSidePlatoon.RemoveSoldier(_leftSideSoldier);
            }
            else if (_rightSideSoldier.Health <= 0)
            {
                _rightSidePlatoon.RemoveSoldier(_rightSideSoldier);
            }
        }
    }

    class Platoon
    {
        private readonly List<Soldier> _soldiers = new List<Soldier>();
        private static readonly Random Random = new Random();

        public Platoon()
        {
            CreatePlatoon(6);
        }

        public void ShowPlatoon()
        {
            foreach (var soldier in _soldiers)
            {
                Console.WriteLine($"Должность {soldier.Name}. Здоровье {soldier.Health}. Атака {soldier.Damage}");
            }
        }

        public int GetSoldiersCount()
        {
            return _soldiers.Count;
        }

        public Soldier GetRandomSoldier()
        {
            int soldierIndex = Random.Next(_soldiers.Count);
            return _soldiers[soldierIndex];
        }

        public void RemoveSoldier(Soldier soldier)
        {
            _soldiers.Remove(soldier);
        }

        private Soldier GetTypedSoldier()
        {
            int lastPositionSoldier = 4;
            int soldierInPlatoon = Random.Next(lastPositionSoldier);

            switch (soldierInPlatoon)
            {
                case 1:
                    return new BlackSmith("Кузнец", 85, 20);
                case 2:
                    return new Doctor("Доктор", 100, 12);
                case 3:
                    return new Kamikaze("Камикадзе", 50, 20);
                default:
                    return new Sniper("Снайпер", 50, 25);
            }
        }        

        private void CreatePlatoon(int soldiersCount)
        {
            for (int i = 0; i < soldiersCount; i++)
            {
                _soldiers.Add(GetTypedSoldier());
            }
        }
    }

    class Soldier
    {
        private readonly Random _random = new Random();
        public string Name { get; private set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }

        protected Soldier(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void UseSpecial()
        {
            int allPercents = 100;
            int specialChance = 50;
            int randomValue = _random.Next(allPercents);

            if (randomValue > specialChance)
            {
                SpecialAttack();
            }
        }

        protected virtual void SpecialAttack() { }
    }

    class BlackSmith : Soldier
    {
        private int _sharpenSwords = 5;

        public BlackSmith(string name, int health, int damage) : base(name, health, damage) { }

        protected override void SpecialAttack()
        {
            Console.WriteLine($"Кузнец заточил мечи. Атака увеличена на {_sharpenSwords} единиц.");
            Damage += _sharpenSwords;
        }
    }

    class Doctor : Soldier
    {
        private int _healingPower = 20;

        public Doctor(string name, int health, int damage) : base(name, health, damage) { }

        protected override void SpecialAttack()
        {
            Console.WriteLine($"Доктор полечился на {_healingPower} единиц.");
            Health += _healingPower;
        }
    }

    class Kamikaze : Soldier
    {
        private int _maxHealth;
        
        public Kamikaze(string name, int health, int damage) : base(name, health, damage) 
        {
            _maxHealth = health; 
        }

        protected override void SpecialAttack()
        {
            Console.WriteLine("Камикадзе подрывает себя.");
            Damage *= 5;
            Health -= _maxHealth;
        }
    }

    class Sniper : Soldier
    {
        private int _startDamage;
        
        public Sniper(string name, int health, int damage) : base(name, health, damage)
        {
            _startDamage = damage;
        }

        protected override void SpecialAttack()
        {
            Random random = new Random();
        
            int allPercents = 100;
            int critChance = 50;
            int randomValue = random.Next(allPercents);

            if (randomValue > critChance)
            {
                Damage *= 2;
            }
            else
            {
                Damage = _startDamage;
            }
        }
    }
}
