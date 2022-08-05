using System;
using System.Collections.Generic;
using System.Linq;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            Detective detective = new Detective();

            var thieves = detective.FindByData(180, 85, "Американец");
            detective.DisplayThieves(thieves);
        }
    }

    class Thief
    {
        public string Name { get; private set; }
        public bool IsInJail { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }

        public Thief(string name, bool isInJail, int height, int weight, string nationality)
        {
            Name = name;
            IsInJail = isInJail;
            Height = height;
            Weight = weight;
            Nationality = nationality;
        }
    }

    class Detective
    {
        private readonly List<Thief> _thieves = new List<Thief>();

        public Detective()
        {
            _thieves.Add(new Thief("Олег",true, 175, 80, "Азиат"));
            _thieves.Add(new Thief("Антон",false, 180, 85, "Американец"));
            _thieves.Add(new Thief("Артем",true, 192, 90, "Европеец"));
            _thieves.Add(new Thief("Алексей",true, 165, 65, "Гуманоид"));
            _thieves.Add(new Thief("Александр",false, 188, 74, "Темнокожий"));
        }

        public List<Thief> FindByData(int height, int weight, string nationality)
        {
            var sortedThieves = from Thief thief in _thieves
                where thief.Height == height
                where thief.Nationality == nationality
                where thief.Weight == weight
                where thief.IsInJail == false
                select thief;
            return sortedThieves.ToList();
        }

        public void DisplayThieves(List<Thief> thieves)
        {
            foreach (var thief in thieves)
            {
                Console.WriteLine(thief.Name);
            }
        }
    }
}