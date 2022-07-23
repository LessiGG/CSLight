using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CSLight
{
    class PlayersDataBase
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();

            Player playerAndrew = new Player(18, "Andrew");
            
            dataBase.AddPlayer(playerAndrew);
            dataBase.AddPlayer(28, "Nick");
            dataBase.AddPlayer(22, "George");
            dataBase.ShowPlayers();
            dataBase.BanPlayer(22);
            dataBase.ShowPlayers();
            dataBase.ShowBannedPlayers();
            dataBase.UnbanPlayer(22);
            dataBase.ShowBannedPlayers();
            dataBase.ShowPlayers();
            dataBase.RemovePlayer(18);
            dataBase.ShowPlayers();
            dataBase.BanPlayer(28);
            dataBase.CheckIsBanned(28);
        }
    }

    class Player
    {
        private bool _isBanned;
        private int _level;
        
        public int Id { get; }
        public string Nickname { get; }
        
        public Player(int id, string nickname)
        {
            Id = id;
            Nickname = nickname;
        }

        public void GetBanned()
        {
            _isBanned = true;
        }

        public void GetUnbanned()
        {
            _isBanned = false;
        }
    }

    class DataBase
    {
        private List<Player> _players = new List<Player>();
        private List<Player> _bannedPlayers = new List<Player>();

        public void CheckIsBanned(int id)
        {
            foreach (var bannedPlayer in _bannedPlayers)
            {
                if (bannedPlayer.Id == id)
                {
                    Console.WriteLine($"Пользователь {bannedPlayer.Nickname} забанен.");
                    break;
                }
            }
        }

        public void ShowPlayers()
        {
            Console.WriteLine("Список игроков:");
            
            foreach (var player in _players)
            {
                Console.WriteLine(player.Nickname);
            }

            Console.WriteLine();
        }

        public void ShowBannedPlayers()
        {
            Console.WriteLine("Забаненные игроки:");
            
            foreach (var banned in _bannedPlayers)
            {
                Console.WriteLine(banned.Nickname);
            }

            Console.WriteLine();
        }


        public void AddPlayer(int id, string nickname)
        {
            Player player = new Player(id, nickname);
            _players.Add(player);
        }
        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public void RemovePlayer(int id)
        {
            foreach (var player in _players)
            {
                if (player.Id == id)
                {
                    _players.Remove(player);
                    break;
                }
            }
        }

        public void BanPlayer(int id)
        {
            foreach (var player in _players)
            {
                if (player.Id == id)
                {
                    player.GetBanned();
                    _players.Remove(player);
                    _bannedPlayers.Add(player);
                    break;
                }
            }
        }
        
        public void UnbanPlayer(int id)
        {
            foreach (var bannedPlayer in _bannedPlayers)
            {
                if (bannedPlayer.Id == id)
                {
                    bannedPlayer.GetUnbanned();
                    _bannedPlayers.Remove(bannedPlayer);
                    _players.Add(bannedPlayer);
                    break;
                }
            }
        }
    }
}