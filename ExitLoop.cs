using System;

namespace CSLight
{
    class ExitLoop
    {
        static void Main(string[] args)
        {
            string exitWord = "exit";
            string userInput;
            bool exitConditionMet = false;
            
            while (!exitConditionMet)
            {
                Console.Write("Если хотите выйти из программы введите exit: ");
                userInput = Console.ReadLine();
                
                if (userInput == exitWord)
                    exitConditionMet = true;
            }
        }
    }
}