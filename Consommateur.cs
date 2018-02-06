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
            while (communicateQueue.Dequeue(out integer))
            {
                try
                {
                    sortedList.Add(integer, integer);
                }
                catch (ArgumentException)
                {
                    // Impossible to add an duplicate keys on outputList.
                    communicateQueue.DuplicateKeysAppears();
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error appears : " + e.Message);
                }
            }
        }
    }
}

