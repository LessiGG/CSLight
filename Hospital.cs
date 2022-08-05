using System;
using System.Collections.Generic;
using System.Linq;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            Hospital hospital = new Hospital();
            
            while (isWorking)
            {
                Console.WriteLine("[1] Отсортировать по ФИО [2] Отсортировать по возрасту [3] Вывести больных с определенным заболеванием [4] Выход");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        hospital.SortByName();
                        break;
                    case "2":
                        hospital.SortByAge();
                        break;
                    case "3":
                        hospital.ShowPatientsByIllness();
                        break;
                    case "4":
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Неизвестная операция.");
                        break;
                }
            }
        }
    }

    class Patient
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Illness { get; private set; }

        public Patient(string name, int age, string illness)
        {
            Name = name;
            Age = age;
            Illness = illness;
        }
    }

    class Hospital
    {
        private readonly List<Patient> _patients = new List<Patient>();

        public Hospital()
        {
            _patients.Add(new Patient("Ваня", 19, "Аутизм"));
            _patients.Add(new Patient("Олег", 20, "Простуда"));
            _patients.Add(new Patient("Артем", 15, "Рак"));
            _patients.Add(new Patient("Вадим", 18, "Лейкимия"));
            _patients.Add(new Patient("Алексей", 19, "Грипп"));
            _patients.Add(new Patient("Роман", 78, "Сколиоз"));
            _patients.Add(new Patient("Григорий", 36, "Склероз"));
            _patients.Add(new Patient("Лев", 23, "Герпис"));
            _patients.Add(new Patient("Антон", 8, "Спид"));
            _patients.Add(new Patient("Максим", 29, "Вич"));
        } 
        
        public void SortByName()
        {
            var sortedPatients = _patients.OrderBy(patient => patient.Name).ToList();
            DisplayPatients(sortedPatients);
        }

        public void SortByAge()
        {
            var sortedPatients = _patients.OrderBy(patient => patient.Age).ToList();
            DisplayPatients(sortedPatients);
        }

        public void ShowPatientsByIllness()
        {
            string illness = Console.ReadLine();
            
            var sortedPatients = _patients.Where(patient => patient.Illness.ToLower() == illness?.ToLower()).ToList();
            DisplayPatients(sortedPatients);
        }
        
        private void DisplayPatients(List<Patient> patients)
        {
            foreach (var patient in patients)
            {
                Console.WriteLine($"Имя: {patient.Name}, Возраст: {patient.Age}, Болезнь: {patient.Illness}");
            }
        }
    }
}
