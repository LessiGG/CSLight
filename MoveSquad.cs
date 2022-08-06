using System;
using System.Collections.Generic;
using System.Linq;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            Squad squad = new Squad();
            
            squad.Show();
            squad.TransferSoldiers();
            squad.Show();
        }
    }

    class Soldier
    {
        public string Surname { get; private set; }

        public Soldier(string surname)
        {
            Surname = surname;
        }
    }

    class Squad
    {
        private List<Soldier> _soldiersA = new List<Soldier>();
        private List<Soldier> _soldiersB = new List<Soldier>();

        public Squad()
        {
            _soldiersA.Add(new Soldier("Буханкин"));
            _soldiersA.Add(new Soldier("Баранканкин"));
            _soldiersA.Add(new Soldier("Бубликов"));
            _soldiersA.Add(new Soldier("Абрикосов"));
            _soldiersA.Add(new Soldier("Пушкин"));
        }

        public void Show()
        {
            Console.WriteLine("Отряд 1:");
            
            foreach (var soldier in _soldiersA)
            {
                Console.WriteLine(soldier.Surname);
            }
            
            Console.WriteLine("Отряд 2:");
            
            foreach (var soldier in _soldiersB)
            {
                Console.WriteLine(soldier.Surname);
            }
        }

        public void TransferSoldiers()
        {
            var soldiers = _soldiersA.Where(soldier => soldier.Surname.StartsWith("Б")).ToList();
            
            _soldiersB = _soldiersB.Union(soldiers).ToList();
            _soldiersA = _soldiersA.Except(soldiers).ToList();
        }
    }
}
