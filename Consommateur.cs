using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ProducteurConsommateur
{
    public class Consommateur
    {
        private Thread threadConsommateur;
        private QueueToProduceAndSort cqueue;
        private List<int> listToSort;
        public bool IsFinish { get; private set; }
        public Consommateur(QueueToProduceAndSort Cqueue)
        {
            cqueue = Cqueue;
            listToSort = new List<int>();
            IsFinish = false;
        }

        public void Run()
        {
            threadConsommateur = new Thread(() => Consume());
            threadConsommateur.Start();
        }

        private void DisplaySortedList()
        {
            foreach(int nb in listToSort)
            {
                Console.WriteLine(nb);
            }
            Console.ReadLine();
        }

        private void Consume()
        {
            lock (cqueue)
            {
                while ((cqueue.ConcurrentQueue.Count != 0 || !cqueue.IsFinish))
                {
                    if (cqueue.ConcurrentQueue.Count == 0 && !cqueue.IsFinish)
                    {
                        Monitor.Wait(cqueue);
                    }
                    int _output;
                    if (cqueue.ConcurrentQueue.TryDequeue(out _output))
                    {
                        InsertSorted(_output);
                    }
                }
            }
            IsFinish = true;
            DisplaySortedList();
        }

        private void InsertSorted(int _output)
        {
            listToSort.Add(_output);
            listToSort.Sort();
        }
    }
}
