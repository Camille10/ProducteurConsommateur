using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProducteurConsommateur.Tests
{
    [TestClass()]
    public class ConsommateurTests
    {
        private OutputList sortedList = new OutputList();
        private LinkedList<int> c = new LinkedList<int>();
        QueueToProduceAndSort cqueue = new QueueToProduceAndSort(nbElement);
        Consommateur consommateur;
        private static int nbElement = 1000;

        public ConsommateurTests()
        {
            consommateur = new Consommateur(cqueue, sortedList);
        }

        public void FillQueue()
        {
            Random _rnd = new Random();
            for (int _index = 0; _index < nbElement; _index++)
            {
                cqueue.Enqueue(_rnd.Next());
            }
            consommateur.Run();
            while (!(cqueue.IsFinished && cqueue.IsEmpty)) { }
        }
    }
}
