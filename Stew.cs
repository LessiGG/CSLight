using System;
using System.Collections.Generic;
using System.Linq;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            storage.DisplayExpiredStew();
        }
    }

    class Stew
    {
        private static readonly Random _random = new Random();
        
        public string Name { get; private set; }
        public int YearOfProduction { get; private set; }
        public int ExpirationDate { get; private set; }

        private int _minProductionYear = 1950;
        private int _maxProductionYear = 2022;
        private int _minExpirationDate = 5;
        private int _maxExpirationDate = 20;

        public Stew(string name)
        {
            Name = name;
            YearOfProduction = GetYearOfProduction;
            ExpirationDate = GetExpirationDate;
        }

        private int GetYearOfProduction => _random.Next(_minProductionYear, _maxProductionYear);
        private int GetExpirationDate => _random.Next(_minExpirationDate, _maxExpirationDate);
    }

    class Storage
    {
        private readonly List<Stew> _stews = new List<Stew>();

        private int _currentYear = 2022;

        public Storage()
        {
            _stews.Add(new Stew("Коровка"));
            _stews.Add(new Stew("Буренка"));
            _stews.Add(new Stew("Бык"));
            _stews.Add(new Stew("Говядина"));
            _stews.Add(new Stew("Телятина"));
            _stews.Add(new Stew("Свинина"));
            _stews.Add(new Stew("Утка"));
        }

        public void DisplayExpiredStew()
        {
            foreach (var stew in _stews.Where(stew => stew.YearOfProduction + stew.ExpirationDate > _currentYear))
            {
                Console.WriteLine(stew.Name);
            }
        }
    }
}