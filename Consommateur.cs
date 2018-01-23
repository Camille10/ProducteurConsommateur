using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace ProducteurConsommateur
{
    public class Consommateur
    {
        private QueueToProduceAndSort queue;
        private List<int> sortedList = new List<int>();
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
                sortedList.Add(integer);
                sortedList.Sort();
            }
            DisplaySortedList();
        }
        private void DisplaySortedList()
        {
            foreach (int nb in sortedList)
            {
                Console.WriteLine(nb);
            }
            Console.ReadLine();
        }
    }
}
