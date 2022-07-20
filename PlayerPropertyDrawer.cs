using System;

namespace CSLight
{
    class PlayerPropertyDrawer
    {
        static void Main(string[] args)
        {
            int playerPositionX = 5;
            int playerPositionY = 5;
            char playerSymbol = '@';
            
            Player player = new Player(playerPositionX, playerPositionY, playerSymbol);
            PlayerDrawer playerDrawer = new PlayerDrawer();
            playerDrawer.DrawPlayer(player);
        }
    }

    class Player
    {
        private int _positionX;
        private int _positionY;
        private char _playerSymbol;

        public int PositionX
        {
            get
            {
                return _positionX;
            }
        }
        
        public int PositionY
        {
            get
            {
                return _positionY;
            }
        }
        
        public char PlayerSymbol
        {
            get
            {
                return _playerSymbol;
            }
        }
        
        public Player(int positionX, int positionY, char playerSymbol)
        {
            _positionX = positionX;
            _positionY = positionY;
            _playerSymbol = playerSymbol;
        }
    }

    class PlayerDrawer
    {
        public void DrawPlayer(Player player)
        {
            Console.SetCursorPosition(player.PositionX, player.PositionY);
            Console.WriteLine(player.PlayerSymbol);
        }
    }
} 