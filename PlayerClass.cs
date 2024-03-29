﻿using System;

namespace CSLight
{
    class PlayerClass
    {
        static void Main(string[] args)
        {
            int playerHealth = 100;
            float playerPositionX = 5.0f;
            float playerPositionY = 7.0f;
            
            Player player = new Player(playerHealth, playerPositionX, playerPositionY);
            player.ShowInfo();
        }
    }

    class Player
    {
        private int _health;
        private float _positionX;
        private float _positionY;
        
        public Player(int health, float positionX, float positionY)
        {
            _health = health;
            _positionX = positionX;
            _positionY = positionY;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"У игрока {_health} очков здоровья, игрок находится в позиции {_positionX} по X и {_positionY} по Y.");
        }
    }
} 
