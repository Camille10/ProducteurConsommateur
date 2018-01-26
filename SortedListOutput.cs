using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProducteurConsommateur
{
    public class OutputList
    {
        public SortedList<int, int> sortedList = new SortedList<int, int>();

        public void Add(int key,int value)
        {
            Monitor.Enter(this);
            try
            {
                sortedList.Add(key, value);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Duplicate Keys appears. Element not inserted");
            }
            finally
            {
                Monitor.Exit(this);
            }
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
