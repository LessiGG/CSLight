using System;

namespace CSLight
{
    public class BarDrawer
    {
        static void Main(string[] args)
        {
            int healthBarPositionX = 0;
            int healthBarPositionY = 0;
            int healthBarPercent = 52;
            
            int manaBarPositionX = 0;
            int manaBarPositionY = 1;
            int manaBarPercent = 96;
            
            DrawBar(healthBarPositionX, healthBarPositionY, healthBarPercent, ConsoleColor.DarkRed);
            DrawBar(manaBarPositionX, manaBarPositionY, manaBarPercent, ConsoleColor.DarkBlue);
        }

        static void DrawBar(int positionX, int positionY, int percent, ConsoleColor color, char symbol = ' ')
        {
            int cells = 10;
            int allPercents = 100;
            int value = (cells * percent) / allPercents;
            ConsoleColor defaultColor = Console.BackgroundColor;
            
            Console.SetCursorPosition(positionX, positionY);
            Console.Write('[');
            Console.BackgroundColor = color;

            string bar = "";

            for (int i = 0; i < value; i++)
            {
                bar += symbol;
            }
            
            Console.Write(bar);
            Console.BackgroundColor = defaultColor;

            bar = "";

            for (int i = value; i < cells; i++)
            {
                bar += symbol;
            }
            
            Console.Write(bar + ']');
        }
    }
}