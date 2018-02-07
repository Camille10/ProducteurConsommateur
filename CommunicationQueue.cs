using System.Collections.Generic;
using System.Threading;

namespace ProducteurConsommateur
{
    public class CommunicationQueue
    {
        private Queue<int> queue = new Queue<int>();
        public bool IsFinished { get; private set; } = false;
        public bool IsEmpty { get; private set; } = true;
        private int nbElementToInsert;
        private int NbElementInserted;
        private ManualResetEvent events = new ManualResetEvent(false);
        private Mutex mutex = new Mutex();

        public CommunicationQueue(int maxElements)
        {
            nbElementToInsert = maxElements;
        }

        public void DuplicateKeysAppears()
        {
            lock (this)
            {
                NbElementInserted--;
                if (IsFinished)
                {
                    IsFinished = false;
                }
                events.Set();
            }
        }

        public bool Enqueue(int integer)
        {
            lock (this) {
                if (IsFinished)
                {
                    return false;
                }
                queue.Enqueue(integer);
                IsEmpty = false;
                if (++NbElementInserted == nbElementToInsert)
                {
                    IsFinished = true;
                }
                events.Set();
            }

            return true;
        }

        public bool Dequeue(out int integer)
        {
            lock (this)
            {
                if ((IsFinished) && (queue.Count == 0))
                {
                    IsEmpty = true;
                    
                    integer = int.MinValue;
                    return false;
                }
                while (queue.Count == 0)
                {
                    IsEmpty = true;
                    events.WaitOne();
                }
                integer = queue.Dequeue();
                events.Set();
            }
            
            return true;
        }

    }
}
