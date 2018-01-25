using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducteurConsommateur
{
    public class SortedListOutput
    {
        public SortedList<int, int> sortedList = new SortedList<int, int>();

        public void Add(int key,int value)
        {
            Monitor.Enter(this);
            sortedList.Add(key, value);
            Monitor.Exit(this);
        }

        public void DisplaySortedList()
        {
            foreach (int number in sortedList.Values)
            {
                Console.WriteLine(number);
            }
            Console.ReadLine();
        }
    }
}
