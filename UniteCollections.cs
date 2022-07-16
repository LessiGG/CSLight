using System;
using System.Collections.Generic;

namespace CSLight
{
    class UniteCollections
    {
        static void Main(string[] args)
        {
            string[] firstArray = {"1", "2", "1", "1", "2", "4"};
            string[] secondArray = {"3", "2"};

            List<string> unitedCollection = new List<string>();
            
            FillList(unitedCollection, firstArray);
            FillList(unitedCollection, secondArray);
            PrintList(unitedCollection);
        }

        static void FillList(List<string> list, string[] array)
        {
            foreach (var arrayItem in array)
            {
                if (list.Contains(arrayItem) == false)
                {
                    list.Add(arrayItem);
                }
            }
        }

        static void PrintList(List<string> list)
        {
            foreach (var listItem in list)
            {
                Console.Write(listItem + " ");
            }
        }
    }
}
