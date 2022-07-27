using System;
using System.Collections.Generic;

namespace CSLight
{
    class FightingClub
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena();
            bool isFighting = true;
            
            while (isFighting)
            {
                if (arena.TryCreateBattle())
                {
                    Console.WriteLine("Нажмите любую клавишу чтобы посмотреть бой!");
                    Console.ReadKey();
                    Console.Clear();
                    arena.Battle();       
                    isFighting = false;
                }
                else
                {
                    Console.WriteLine("Не получилось устроить бой. Нажмите любую клавишу чтобы попробовать снова...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }

    class Arena
    {
        private readonly List<Fighter> _fighters = new List<Fighter>();
        
        private Fighter _firstFighter;
        private Fighter _secondFigther;
        
        public Arena()
        {
            _fighters.Add(new Gladiator("Гладиатор", 500, 20));
            _fighters.Add(new Assasin("Убийца", 450, 30));
            _fighters.Add(new Barbarian("Варвар", 600, 25));
            _fighters.Add(new Monk("Монах", 400, 20));
            _fighters.Add(new Mage("Маг", 450, 10));
        }
        
        public void Battle()
        {
            while (_firstFighter.Health > 0 && _secondFigther.Health > 0)
            {
                _firstFighter.ShowStats();
                _secondFigther.ShowStats();
                _firstFighter.Attack(_secondFigther);
                _secondFigther.Attack(_firstFighter);
                Console.WriteLine("\nНажмите любую клавишу чтобы продолжить...");
                Console.ReadLine();
                Console.Clear();
            } 
            
            ShowWinner();
        }
        
        public bool TryCreateBattle()
        {
            ShowFighters();
            Console.WriteLine("Выберите первого бойца: ");
            
            if (TryChooseFighter(out _firstFighter) != false)
            {
                Console.WriteLine("Выберите второго бойца: ");
            
                if (TryChooseFighter(out _secondFigther) != false)
                {
                    if (_firstFighter != _secondFigther)
                    {
                        Console.WriteLine("Выбор сделан, битва началась!\n");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Выберите разных воинов!");
                    }
                }
            }
            
            return false;
        }

        private void ShowWinner()
        {
            Console.WriteLine("Бой окончен. Итог:");
            
            
            if (_firstFighter.Health <= 0)
            {
                Console.WriteLine($"Победил {_secondFigther.Name}");
            }
            else if (_secondFigther.Health <= 0)
            {
                Console.WriteLine($"Победил {_firstFighter.Name}");
            }
            else
            {
                Console.WriteLine("Оба бойца в нокауте.");
            }
        }

        private bool TryChooseFighter(out Fighter fighter)
        {
            bool isNumber = int.TryParse(Console.ReadLine(), out int id);

            if (isNumber == false)
            {
                Console.WriteLine("Введите номер бойца.");
                fighter = null;
                return false;
            }
            
            if (id > 0 && id <= _fighters.Count)
            {
                fighter = _fighters[id - 1];
                Console.WriteLine($"Вы выбрали бойца {fighter.Name}");
                return true;
            }
            
            Console.WriteLine("Нет бойца под таким номером!");
            fighter = null;
            return false;
        }

        private void ShowFighters()
        {
            for (int i = 0; i < _fighters.Count; i++)
            {
                Console.Write(i + 1 + " ");
                _fighters[i].ShowStats();
            }
        }
    }
    
    class Fighter
    {
        protected int StartDamage;
        
        public string Name { get; private set; }
        public int Health { get; protected set; }
        protected int Damage { get; set; }

        protected Fighter(string name, int health, int damage)
        {           
            Name = name;
            Health = health;
            Damage = damage;
            StartDamage = damage;
        }

        public void ShowStats()
        {
            Console.WriteLine($"{Name}, здоровье: {Health}, атака: {Damage}");
        }  

        public void Attack(Fighter enemy)
        {
            UseClassAttack();
            enemy.TakeDamage(Damage);
            Damage = StartDamage;
        }     

        private void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} получает {damage} урона");
        }

        protected virtual void UseClassAttack() { }       
    }
    
    class Gladiator: Fighter
    {
        private int _attacksCount;

        public Gladiator(string name, int health, int damage) : base(name, health, damage)
        {
            StartDamage = damage;
        }

        protected override void UseClassAttack()
        {
            _attacksCount++;

            if (_attacksCount % 3 == 0)
            {
                Damage *= 2;
            }
            else
            {
                Damage = StartDamage;
            }
        }
    }

    class Monk: Fighter
    {
        private int _healingPerAttack = 10;
        
        public Monk(string name, int health, int damage) : base(name, health, damage) { }

        protected override void UseClassAttack()
        {
            Health += _healingPerAttack;
            Console.WriteLine($"Монах восстановил {_healingPerAttack} очков здоровья.");
        }
    }

    class Assasin: Fighter
    {
        private readonly int _maxHealth;

        public Assasin(string name, int health, int damage) : base(name, health, damage)
        {
            _maxHealth = health;
        }

        protected override void UseClassAttack()
        {
            if (Health < _maxHealth / 2)
            {
                Damage *= 2;
            }
            else
            {
                Damage = StartDamage;
            }
        }
    }

    class Barbarian: Fighter
    {
        private readonly Random _random = new Random();
        
        private int _percentageChanceToCrit = 30;
        
        public Barbarian(string name, int health, int damage) : base(name, health, damage) { }

        protected override void UseClassAttack()
        {
            int allPercents = 100;
            int randomValue = _random.Next(allPercents);

            if (randomValue < _percentageChanceToCrit)
            {
                Damage *= 3;
            }
            else
            {
                Damage = StartDamage;
            }
        }
    }

    class Mage: Fighter
    {
        private readonly Random _random = new Random();
        
        private int _mana;
        private int _minManaAmount = 30;
        private int _maxManaAmount = 100;
        
        private int _fireballCost = 30;
        private int _minFireballPower = 50;
        private int _maxFireballPower = 100;

        public Mage(string name, int health, int damage) : base(name, health, damage)
        {
            _mana = _random.Next(_minManaAmount, _maxManaAmount);
        }

        protected override void UseClassAttack()
        {
            int fireballDamage = _random.Next(_minFireballPower, _maxFireballPower);
            
            if (_mana > _fireballCost)
            {
                Damage = fireballDamage;
                _mana -= _fireballCost;
                Console.WriteLine($"Маг использует файрбол и наносит {fireballDamage} урона. Маны осталось: {_mana}");
            }
            else
            {
                Damage = StartDamage;
            }
        }
    }
}
