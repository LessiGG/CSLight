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
            foreach (var item in array)
            {
                if (list.Contains(item) == false)
                {
                    list.Add(item);
                }
            }
        }

        static void PrintList(List<string> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
        }
    }
} 