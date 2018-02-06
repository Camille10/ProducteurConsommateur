using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ProducteurConsommateur
{
    public class Producteur
    {
        private CommunicationQueue queue;
        private Thread thread;
        public Producteur(CommunicationQueue cqueue)
        {
            queue = cqueue;
        }

        public void Run()
        {
            thread = new Thread(() => Produce());
            thread.Start();
        }

        private void Produce()
        {
            Random randomNumberGenerator = new Random();
            while (queue.Enqueue(randomNumberGenerator.Next()))
            {
                //Thread.Sleep(5000);
            }
        }
    }
}
