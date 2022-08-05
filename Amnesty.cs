using System;
using System.Collections.Generic;
using System.Linq;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            City city = new City();
            
            city.ShowCitizens();
            city.PerformAmnesty();
            city.RemoveGuiltyCitizens();
            city.ShowCitizens();
        }
    }

    class Citizen
    {
        public string Name { get; private set; }
        public bool IsGuilty { get; private set; }

        public Citizen(string name)
        {
            Name = name;
            IsGuilty = false;
        }

        public void BecomeGuilty()
        {
            IsGuilty = true;
        }
    }

    class City
    {
        private readonly Random _random = new Random();
        private List<Citizen> _citizens = new List<Citizen>();

        public City()
        {
            _citizens.Add(new Citizen("Олег"));
            _citizens.Add(new Citizen("Андрей"));
            _citizens.Add(new Citizen("Вячеслав"));
            _citizens.Add(new Citizen("Артемий"));
            _citizens.Add(new Citizen("Максим"));
        }

        public void ShowCitizens()
        {
            foreach (var citizen in _citizens)
            {
                Console.WriteLine(citizen.Name);
            }

            Console.WriteLine("------------------");
        }

        public void RemoveGuiltyCitizens()
        {
            var citizens = (from Citizen citizen in _citizens
                where citizen.IsGuilty == false
                select citizen).ToList();
            _citizens = citizens;
        }

        public void PerformAmnesty()
        {
            foreach (var citizen in _citizens.Where(human => _random.Next(2) == 0))
            {
                citizen.BecomeGuilty();
            }
        }
    }
}
