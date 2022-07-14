using System;
using System.IO;

namespace CSLight
{
    public class DrawMap
    {
        static char[,] map;
        static int[] mapInfo; // 0 - xmax, 1 - ymax,  
        static int[] currentPos;
        static void Main(string[] args)
        {
            currentPos = new int[2] { 0, 0 };
            Console.WriteLine("(0 - create map | 1 - load map)");
            var k = Console.ReadKey();
            if (k.Key == ConsoleKey.D0)
            {
                Console.Clear();
                Console.WriteLine("0 - create random | 1 - self create");
                k = Console.ReadKey();
                if (k.Key == ConsoleKey.D0)
                {
 
                }
                else if (k.Key == ConsoleKey.D1)
                {
                    SelfCreateMap();
                }
            }
            if (k.Key == ConsoleKey.D1)
            {
                playGame();
            }
        }
 
        static void WriteMap(int[] currentPos)
        {
            for (int i = 0; i < mapInfo[1]; i++)
            {
                for (int i2 = 0; i2 < mapInfo[0]; i2++)
                {
                    if(i == currentPos[0] && i2 == currentPos[1]) Console.Write('O'); 
                    else Console.Write(map[i, i2]);
                }
                Console.WriteLine();
            }
        }
 
        static char[,] ReadMap(string fileName)
        {
            string[] map = File.ReadAllLines(fileName);
            mapInfo = new int[2] { map[0].Length, map.Length };
            char[,] cMap = new char[mapInfo[1], mapInfo[0]];
            for (int i = 0; i < mapInfo[1]; i++)
            {
                for (int j = 0; j< mapInfo[0]; j++)
                {
                    if (map[i][j] == 'S')
                    {
                        currentPos[0] = i;
                        currentPos[1] = j;
                        cMap[i, j] = ' ';
                    }
                    else
                    {
                        cMap[i, j] = map[i][j];
                    }
                }
            }
            return cMap;
 
 
        }
        static void SelfCreateMap()
        {
            Console.Clear();
            Console.Write("Введите количество строк: ");
            int rows = Int32.Parse(Console.ReadLine());
            
            Console.Write("\nВведите количество столбцов: ");
            int columns = Int32.Parse(Console.ReadLine());
            
            Console.WriteLine("\nВведите название карты: ");
            string fileName = Console.ReadLine();
            StreamWriter toFile = new StreamWriter(fileName);
            bool oneSpawn = false;
            Console.Clear();
            for (int i = 0; i < columns; i++)
            {
                for (int i2 = 0; i2 < rows; i2++)
                {
 
                    ConsoleKeyInfo key;
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.S && !oneSpawn)
                    {
                        toFile.Write(key.KeyChar);
                        oneSpawn = true;
                    } 
                    if (key.Key == ConsoleKey.D0 || key.Key == ConsoleKey.D1)
                        toFile.Write(key.KeyChar);
                }
                toFile.WriteLine();
                Console.WriteLine();
            }
            toFile.Close();
            Console.Clear();
            playGame();
        }
 
        static void playGame()
        {
            Console.Write("\nВведи название карты для загрузки: ");
            string filename = Console.ReadLine();
            map = ReadMap(filename);
            Console.Clear();
            WriteMap(currentPos);
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();
 
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (map[currentPos[0] - 1, currentPos[1]] == ' ')
                    {
                        currentPos[0] -= 1;
 
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (map[currentPos[0] + 1, currentPos[1]] == ' ')
                    {
                        currentPos[0] += 1;
 
                    }
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (map[currentPos[0], currentPos[1] - 1] == ' ')
                    {
                        currentPos[1] -= 1;
 
                    }
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    if (map[currentPos[0], currentPos[1] + 1] == ' ')
                    {
                        currentPos[1] += 1;
 
                    }
                }
                Console.Clear();
                WriteMap(currentPos);
            }
            while (key.Key != ConsoleKey.Escape);
        }
    }
}