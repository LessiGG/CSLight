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
        public int PositionX { get; }
        public int PositionY { get; }
        public char PlayerSymbol { get; }
        
        public Player(int positionX, int positionY, char playerSymbol)
        {
            PositionX = positionX;
            PositionY = positionY;
            PlayerSymbol = playerSymbol;
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
