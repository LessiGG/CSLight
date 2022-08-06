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
            
            squad.ShowSquad();
            squad.ChangeSquad();
            squad.ShowSquad();
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
        private List<Soldier> _squadA = new List<Soldier>();
        private List<Soldier> _squadB = new List<Soldier>();

        public Squad()
        {
            _squadA.Add(new Soldier("Буханкин"));
            _squadA.Add(new Soldier("Баранканкин"));
            _squadA.Add(new Soldier("Бубликов"));
            _squadA.Add(new Soldier("Абрикосов"));
            _squadA.Add(new Soldier("Пушкин"));
        }

        public void ShowSquad()
        {
            Console.WriteLine("Отряд 1:");
            
            foreach (var soldier in _squadA)
            {
                Console.WriteLine(soldier.Surname);
            }
            
            Console.WriteLine("Отряд 2:");
            
            foreach (var soldier in _squadB)
            {
                Console.WriteLine(soldier.Surname);
            }
        }

        public void ChangeSquad()
        {
            var soldiers = _squadA.Where(soldier => soldier.Surname.StartsWith("Б")).ToList();
            
            _squadB = _squadB.Union(soldiers).ToList();
            _squadA = _squadA.Except(soldiers).ToList();
        }
    }
}