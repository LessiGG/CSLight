using System;

namespace CSLight
{
    class HospitalQueue
    {
        static void Main(string[] args)
        {
            int peopleInQueue;
            int waitTime = 10;
            int hour = 60;

            Console.Write("Введите количество людей в очереди: ");
            peopleInQueue = Convert.ToInt32(Console.ReadLine());

            int hoursToWait = peopleInQueue * waitTime / hour;
            int minutesToWait = peopleInQueue * waitTime % hour;
            
            Console.WriteLine($"Вы должны отстоять в очереди {hoursToWait} часов и {minutesToWait} минут");
        }
    }
}
