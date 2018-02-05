using System.Collections.Generic;
using System.Threading;

namespace ProducteurConsommateur
{
    public class CommunicateQueue
    {
        private static Queue<int> queue = new Queue<int>();
        public bool IsFinished { get; private set; } = false;
        public bool IsEmpty { get; private set; } = true;
        private static int nbElementToInsert;
        private static int NbElementInserted;

        public CommunicateQueue(int maxElements)
        {
            nbElementToInsert = maxElements;
        }

        public void DuplicateKeysAppears()
        {
            /*if (IsFinished)
            {
                IsFinished = false;
            }*/
        }

        public bool Enqueue(int integer)
        {
            Monitor.Enter(this);
            if (IsFinished)
            {
                Monitor.Exit(this);
                return false;
            }
            queue.Enqueue(integer);
            IsEmpty = false;
            if (++NbElementInserted == nbElementToInsert)
            {
                IsFinished = true;
            }
            Monitor.Pulse(this);
            Monitor.Exit(this);
            return true;
        }

        public bool Dequeue(out int integer)
        {
            Monitor.Enter(this);
            if ((IsFinished) && (queue.Count == 0))
            {
                IsEmpty = true;
                Monitor.Exit(this);
                integer = int.MinValue;
                return false;
            }
            while (queue.Count == 0)
            {
                IsEmpty = true;
                Monitor.Wait(this);
            }
            integer = queue.Dequeue();
            Monitor.Exit(this);
            return true;
        }

    }
}
