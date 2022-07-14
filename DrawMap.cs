using System;
using System.IO;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerPositionX, playerPositionY;
            int playerDirectionX = 0, playerDirectionY = 1;
            char symbolPlayer = '@';
            char[,] map;
            bool isPlaying = true;
            ConsoleKeyInfo inputKey;
            
            Console.WriteLine("[1] создать карту [2] загрузить карту");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    CreateMap();
                    break;
                case "2":
                    break;
            }

            Console.Write("\nВведи название карты для загрузки: ");
            string filename = Console.ReadLine();
            Console.Clear();
            map = ReadMap(filename, symbolPlayer, out playerPositionX, out playerPositionY);
            
            DrawMap(map);
            Console.CursorVisible = false;

            while (isPlaying)
            {
                if (Console.KeyAvailable)
                {
                    inputKey = Console.ReadKey(true);

                    if (inputKey.Key == ConsoleKey.Escape)
                    {
                        isPlaying = false;
                    }
                    else
                    {
                        ChangeDirection(inputKey, ref playerDirectionX, ref playerDirectionY);
                    }

                }
                else if (map[playerPositionX + playerDirectionX, playerPositionY + playerDirectionY] != '#')
                {
                    Move(map, '@', ref playerPositionX, ref playerPositionY, playerDirectionX, playerDirectionY);
                }

                System.Threading.Thread.Sleep(100);
            }
        }

        static char[,] ReadMap(string mapName, char symbolPlayer, out int playerPositionX, out int playerPositionY)
        {
            playerPositionX = 0;
            playerPositionY = 0;
            
            string[] newFile = File.ReadAllLines($"{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == symbolPlayer)
                    {
                        playerPositionX = i;
                        playerPositionY = j;
                    }
                }
            }

            return map;
        }
        
        static void CreateMap()
        {
            Console.Clear();
            Console.Write("Введите количество строк: ");
            int rows = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("\nВведите количество столбцов: ");
            int columns = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("\nВведите название карты: ");
            string fileName = Console.ReadLine() + ".txt";
            StreamWriter toFile = new StreamWriter(fileName);
            Console.Clear();

            Console.WriteLine("Рисуйте карту:");
            
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    ConsoleKeyInfo key;
                    key = Console.ReadKey();
                    toFile.Write(key.KeyChar);
                }
                toFile.WriteLine();
                Console.WriteLine();
            }
            
            toFile.Close();
            Console.Clear();
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }
        }

        static void Move(char[,] map, char symbolPlayer, ref int playerPositionX, ref int playerPositionY, int playerDirectionX, int playerDirectionY)
        {
            Console.SetCursorPosition(playerPositionY, playerPositionX);
            map[playerPositionX, playerPositionY] = ' ';
            Console.Write(map[playerPositionX, playerPositionY]);
            
            playerPositionX += playerDirectionX;
            playerPositionY += playerDirectionY;
            
            Console.SetCursorPosition(playerPositionY, playerPositionX);
            Console.Write(symbolPlayer);
        }

        static void ChangeDirection(ConsoleKeyInfo key, ref int playerDirectionX, ref int playerDirectionY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    playerDirectionX = -1; playerDirectionY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    playerDirectionX = 1; playerDirectionY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    playerDirectionX = 0; playerDirectionY = -1;
                    break;
                case ConsoleKey.RightArrow:
                    playerDirectionX = 0; playerDirectionY = 1;
                    break;
            }
        }
    }
}
