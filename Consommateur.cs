using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace ProducteurConsommateur
{
    public class Consommateur
    {
        private QueueToProduceAndSort queue;
        private SortedListOutput sortedList;
        private Thread thread;

        public Consommateur(QueueToProduceAndSort cqueue, SortedListOutput ListToSort)
        {
            sortedList = ListToSort;
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
                sortedList.Add(integer, integer);
            }
        }
    }
}

