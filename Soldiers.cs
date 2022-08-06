using System;
using System.Collections.Generic;
using System.Linq;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();
            dataBase.DisplayNamesAndRanks();
        }
    }

    class Soldier
    {
        public string Name { get; private set; }
        public string Rank { get; private set; }

        private string _weapon;
        private int _dutyTime;

        public Soldier(string name, string rank, string weapon, int dutyTime)
        {
            Name = name;
            Rank = rank;
            _weapon = weapon;
            _dutyTime = dutyTime;
        }
    }

    class DataBase
    {
        private readonly List<Soldier> _soldiers = new List<Soldier>();

        public DataBase()
        {
            _soldiers.Add(new Soldier("Иван", "Офицер","Палка", 2));
            _soldiers.Add(new Soldier("Наташа","Рядовой", "АК-47", 10));
            _soldiers.Add(new Soldier("Антон","Сержант", "Пистолет", 20));
            _soldiers.Add(new Soldier("Олег", "Командир","Пулемет", 34));
            _soldiers.Add(new Soldier("Андрей","Лейтенант", "Узи", 24));
        }

        public void DisplayNamesAndRanks()
        {
            var soldiersNamesAndRanks = (from Soldier soldier in _soldiers
                select new {soldier.Name, soldier.Rank});
            
            foreach (var data in soldiersNamesAndRanks)
            {
                Console.WriteLine($"Имя солдата: {data.Name}, звание солдата: {data.Rank}");
            }
        }
    }
}