using System;
using System.Collections.Generic;
using System.Linq;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayersManager playersManager = new PlayersManager();
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("[1] Вывести топ 3 по уровню [2] Вывести топ 3 по силе [3] Выход");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        playersManager.SeekByLevel();
                        break;
                    case "2":
                        playersManager.SeekByStrength();
                        break;
                    case "3":
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Неизвестная операция.");
                        break;
                }
            }
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Strength { get; private set; }

        public Player(string name, int level, int strength)
        {
            Name = name;
            Level = level;
            Strength = strength;
        }
    }

    class PlayersManager
    {
        private readonly List<Player> _players = new List<Player>();

        private int _topPlayersCount = 3;

        public PlayersManager()
        {
            _players.Add(new Player("Олег", 20, 500));
            _players.Add(new Player("Артем", 50, 1000));
            _players.Add(new Player("Антон", 80, 10000));
            _players.Add(new Player("Алексей", 230, 71000));
            _players.Add(new Player("Роман", 70, 23232));
            _players.Add(new Player("Иван", 453, 43435));
            _players.Add(new Player("Андрей", 340, 77677));
            _players.Add(new Player("Владимир", 280, 12321));
            _players.Add(new Player("Володя", 210, 23333));
            _players.Add(new Player("Максим", 50, 78654));
        }

        public void SeekByLevel()
        {
            var sortedByLevel = _players.OrderByDescending(player => player.Level).Take(_topPlayersCount).ToList();
            DisplayPlayers(sortedByLevel);
        }

        public void SeekByStrength()
        {
            var sortedByStrength = _players.OrderByDescending(player => player.Strength).Take(_topPlayersCount).ToList();
            DisplayPlayers(sortedByStrength);
        }

        private void DisplayPlayers(List<Player> players)
        {
            foreach (var player in players)
            {
                Console.WriteLine($"Игрок {player.Name}, уровень {player.Level}, сила {player.Strength}");
            }
        }
    }
}