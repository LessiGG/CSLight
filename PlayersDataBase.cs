using System.Collections.Generic;

namespace CSLight
{
    class PlayersDataBase
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();

            Player playerAndrew = new Player(18, "Andrew");
            Player playerMax = new Player(66, "Max");
            
            dataBase.AddPlayer(playerAndrew);
            dataBase.AddPlayer(playerMax);
            
            dataBase.BanPlayer(66);
            dataBase.UnbanPlayer(66);
            dataBase.RemovePlayer(playerMax);
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
        
        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            _players.Remove(player);
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
