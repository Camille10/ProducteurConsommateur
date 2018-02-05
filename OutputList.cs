using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProducteurConsommateur
{
    public class OutputList
    {
        public SortedList<int, int> outputList = new SortedList<int, int>();

        public void Add(int key,int value)
        {
            Monitor.Enter(this);
            try
            {
                outputList.Add(key, value);
            }
            catch (ArgumentException)
            {
                throw;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }
    }
}
