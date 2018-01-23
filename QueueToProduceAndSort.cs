using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ProducteurConsommateur
{
    public class QueueToProduceAndSort
    {
        public ConcurrentQueue<int> ConcurrentQueue;
        public bool IsFinish { get; private set; }
        private int nbElementToInsert;
        private int NbElementInserted;
        public QueueToProduceAndSort(int maxElements)
        {
            ConcurrentQueue = new ConcurrentQueue<int>();
            IsFinish = false;
            nbElementToInsert = maxElements;
        }

        public void Enqueue(int intToAdd)
        {
            ConcurrentQueue.Enqueue(intToAdd);
            NbElementInserted++;
            EnqueueCompleted();
        }

        private void EnqueueCompleted()
        {
            if (NbElementInserted == nbElementToInsert)
            {
                IsFinish = true;
            }
        }
    }
}
