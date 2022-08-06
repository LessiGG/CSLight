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
        }
    }

    class Soldier
    {
        public string Surname { get; private set; }

        public Soldier(string surname)
        {
            Surname = surname;
        }
        
        public void ShowInfo()
        {
            Console.WriteLine($"Фамилия солдата: {Surname}");
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
            Console.WriteLine("Первый отряд:");
            ShowSoldiers(_soldiersA);
            Console.WriteLine("Второй отряд:");
            ShowSoldiers(_soldiersB);
            
            TransferSoldiers();
            
            Console.WriteLine("Второй отряд после перевода:");
            ShowSoldiers(_soldiersB);
            Console.WriteLine("Остатки первого отряда после перевода");
            ShowSoldiers(_soldiersA);
        }

        private void TransferSoldiers()
        {
            var soldiers = _soldiersA.Where(soldier => soldier.Surname.StartsWith("Б")).ToList();
            
            _soldiersB = _soldiersB.Union(soldiers).ToList();
            _soldiersA = _soldiersA.Except(soldiers).ToList();
        }
        
        private void ShowSoldiers(List<Soldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                soldier.ShowInfo();
            }
        }
    }
}
