using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ProducteurConsommateur
{
    public class Producteur
    {
        private int nbAlea;
        private Thread thread;
        private QueueToProduceAndSort cQueue;
        public bool IsFinish { get; private set; }
        public Producteur(QueueToProduceAndSort cqueue, int NbElementToInsert)
        {
            cQueue = cqueue;
            nbAlea = NbElementToInsert;
            IsFinish = false;
        }

        public void Run()
        {
            thread = new Thread(() => Produce());
            thread.Start();
        }

        private void Produce()
        {
            Random _rnd = new Random();
            for (int i =0; i < nbAlea; i++)
            {
                Monitor.Enter(cQueue);
                try
                {
                    cQueue.Enqueue(_rnd.Next(0, 20000));
                    Monitor.Pulse(cQueue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Monitor.Exit(cQueue);
                }
            }
            IsFinish = true;
        }
    }
}
