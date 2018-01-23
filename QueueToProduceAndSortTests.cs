using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProducteurConsommateur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducteurConsommateur.Tests
{
    [TestClass()]
    public class QueueToProduceAndSortTests
    {
        private static int nbElement = 1000;
        QueueToProduceAndSort queueToProduceAndSort;

        public QueueToProduceAndSortTests()
        {
            queueToProduceAndSort = new QueueToProduceAndSort(nbElement);
        }

        [TestMethod()]
        public void ShouldAddElementInQueue()
        {
            Random rnd = new Random();
            int NbToInsert = rnd.Next();
            queueToProduceAndSort.Enqueue(NbToInsert);
            Assert.AreEqual(queueToProduceAndSort.ConcurrentQueue.Count, 1);
        }

        [TestMethod()]
        public void ShouldInQueue()
        {
            Random rnd = new Random();
            int NbToInsert = rnd.Next();
            for (int index = 0; index < nbElement; index++)
            {
                queueToProduceAndSort.Enqueue(NbToInsert);
            }
            Assert.AreEqual(queueToProduceAndSort.IsFinish, true);
        }

    }
}