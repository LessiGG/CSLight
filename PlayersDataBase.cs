using System;
using System.Collections.Generic;

namespace CSLight
{
    class PlayersDataBase
    {
        static void Main(string[] args)
        {
            DataBase database = new DataBase();
            bool isWorking = true;
            
            while (isWorking)
            {
                Console.WriteLine("Выберите действие\n1.Вывести всех игроков\n2.Добавить игрока" +
                                  "\n3.Удалить игрока\n4.Забанить игрока\n5.Разбанить игрока\n6.Выход");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        database.ShowPlayers();
                        break;
                    case "2":
                        database.AddPlayer();
                        break;
                    case "3":
                        database.RemovePlayer();
                        break;
                    case "4":
                        database.BanPlayer();
                        break;
                    case "5":
                        database.UnbanPlayer();
                        break;
                    case "6":
                        isWorking = false;
                        break;
                }
            }
        }
    }

    class Player
    {
        public int Id { get; }
        public string Nickname { get; }
        public bool IsBanned { get; private set; }
        public int Level { get; private set; }
        
        public Player(int id, string nickname)
        {
            Id = id;
            Nickname = nickname;
            Level = 0;
            IsBanned = false;
        }
        
        public void ShowInfo()
        {         
            Console.Write($"ID {Id}. Никнейм игрока {Nickname}. Уровень игрока {Level}. Бан игрока {IsBanned}\n");
        }

        public void Ban()
        {
            IsBanned = true;
        }

        public void Unban()
        {
            IsBanned = false;
        }
    }

    class DataBase
    {
        private List<Player> _players = new List<Player>();
        
        public void ShowPlayers()
        {           
            if (_players.Count == 0)
            {
                Console.WriteLine("В базе нет ни одного игрока");
            }
            else
            {
                foreach (var player in _players)
                {
                    player.ShowInfo();
                }
            }           
        }
        
        public void AddPlayer()
        {
            Console.WriteLine("Введите уникальный айди игрока");
            int.TryParse(Console.ReadLine(), out int id);
            
            if (CheckForUniqueId(id) == true)
            {
                Console.WriteLine("Введите никнейм игрока");
                string nickname = Console.ReadLine();
                        
                Player player = new Player(id, nickname);
                _players.Add(player);
            }
        }

        public bool CheckForUniqueId(int id)
        {
            foreach (var player in _players)
            {
                if (player.Id == id)
                {
                    Console.WriteLine("Такой Id уже существует.");
                    return false;
                }
            }

            return true;
        }

        public void RemovePlayer()
        {
            Console.WriteLine("Введите ID игрока которого хотите удалить");

            if (TryGetPlayer(out Player player))
            {
                _players.Remove(player);
            }  
        }

        public void BanPlayer()
        {
            Console.WriteLine("Введите ID игрока, которого хотите забанить");

            if (TryGetPlayer(out Player player))
            {
                if (player.IsBanned == false)
                {
                    player.Ban();
                }
            }
        }
        
        public void UnbanPlayer()
        {
            Console.WriteLine("Введите ID игрока, которого хотите разабанить");

            if (TryGetPlayer(out Player player))
            {
                if (player.IsBanned == true)
                {
                    player.Unban();
                }                
            }    
        }
        private bool TryGetPlayer(out Player player)
        {
            int inputId = Convert.ToInt32(Console.ReadLine());

            foreach (var gamer in _players)
            {
                if (inputId == gamer.Id)
                {
                    player = gamer;
                    return true;
                }
                
                Console.WriteLine("Такого игрока не существует");
            }

            player = null;
            return false;
        }
    }
}
