using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace ProducteurConsommateur
{
    public class Consommateur
    {
        private QueueToProduceAndSort queue;
        private SortedList<int,int> sortedList = new SortedList<int,int>();
        private Thread thread;

        public Consommateur(QueueToProduceAndSort cqueue)
        {
            queue = cqueue;
        }

        public void Run()
        {
            thread = new Thread(() => Consume());
            thread.Start();
        }

        private void Consume()
        {
            int integer;
            while (queue.Dequeue(out integer))
            {
                sortedList.Add(integer,integer);
            }
            DisplaySortedList();
        }
        private void DisplaySortedList()
        {
            foreach (int number in sortedList.Values)
            {
                Console.WriteLine(number);
            }
            Console.ReadLine();
        }
    }
}
