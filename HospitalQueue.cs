using System;

namespace CSLight
{
    class HospitalQueue
    {
        static void Main(string[] args)
        {
            int peopleInQueue;
            int waitTime = 10;
            int minutesInHour = 60;

            Console.Write("Введите количество людей в очереди: ");
            peopleInQueue = Convert.ToInt32(Console.ReadLine());

            int hoursToWait = peopleInQueue * waitTime / minutesInHour;
            int minutesToWait = peopleInQueue * waitTime % minutesInHour;
            
            Console.WriteLine($"Вы должны отстоять в очереди {hoursToWait} часов и {minutesToWait} минут");
        }
    }
}
