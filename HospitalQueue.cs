using System;

namespace CSLight
{
    class HospitalQueue
    {
        static void Main(string[] args)
        {
            int peopleInQueue;
            int waitTime = 10;

            Console.Write("Введите количество людей в очереди: ");
            peopleInQueue = Convert.ToInt32(Console.ReadLine());

            int hours = peopleInQueue * waitTime / 60;
            int minuts = peopleInQueue * waitTime % 60;
            
            Console.WriteLine($"Вы должны отстоять в очереди {hours} часов и {minuts} минут");
        }
    }
}