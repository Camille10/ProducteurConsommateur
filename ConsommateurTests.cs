using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProducteurConsommateur.Tests
{
    [TestClass()]
    public class ConsommateurTests
    {
        Consommateur consommateur;
        QueueToProduceAndSort cqueue;
        private static int nbElement = 1000;

        public ConsommateurTests()
        {
            cqueue = new QueueToProduceAndSort(nbElement);
            consommateur = new Consommateur(cqueue);
        }

        public void FillQueue()
        {
            Random _rnd = new Random();
            for (int _index = 0; _index < nbElement; _index++)
            {
                cqueue.Enqueue(_rnd.Next(0, 255));
            }
            consommateur.Run();

            while (!consommateur.IsFinish) { }
        }


        [TestMethod()]
        public void ShuouldReturnASortedListWithNbElement()
        {
            FillQueue();
            Assert.AreEqual(nbElement, consommateur.ListToSort.Count);
        }



        [TestMethod()]
        public void ShouldTestSortedList()
        {
            FillQueue();
            int _previousValue = int.MinValue;
            foreach(int _currentValue in consommateur.ListToSort)
            {
                if (_currentValue < _previousValue)
                {
                    Assert.Fail();
                }
            }
            Assert.IsTrue(true);
        }
    }
}