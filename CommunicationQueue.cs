using System.Collections.Generic;
using System.Threading;

namespace ProducteurConsommateur
{
    public class CommunicationQueue
    {
        private static Queue<int> queue = new Queue<int>();
        public bool IsFinished { get; private set; } = false;
        public bool IsEmpty { get; private set; } = true;
        private static int nbElementToInsert;
        private static int NbElementInserted;
        private ManualResetEvent events = new ManualResetEvent(false);
        private static Mutex mutex = new Mutex();

        public CommunicationQueue(int maxElements)
        {
            nbElementToInsert = maxElements;
        }

        public void DuplicateKeysAppears()
        {
            
            mutex.WaitOne();
            NbElementInserted--;
            if (IsFinished)
            {
                IsFinished = false;
            }
            mutex.ReleaseMutex();
            events.Set();
        }

        public bool Enqueue(int integer)
        {
            mutex.WaitOne();
            if (IsFinished)
            {
                mutex.ReleaseMutex();
                return false;
            }
            queue.Enqueue(integer);
            IsEmpty = false;
            if (++NbElementInserted == nbElementToInsert)
            {
                IsFinished = true;
            }
            mutex.ReleaseMutex();
            events.Set();
            return true;
        }

        public bool Dequeue(out int integer)
        {
            mutex.WaitOne();
            if ((IsFinished) && (queue.Count == 0))
            {
                IsEmpty = true;
                mutex.ReleaseMutex();
                integer = int.MinValue;
                return false;
            }
            while (queue.Count == 0)
            {
                IsEmpty = true;
                events.WaitOne();
                //Monitor.Wait(this);
            }
            integer = queue.Dequeue();
            mutex.ReleaseMutex();
            events.Set();
            return true;
        }

    }
}
