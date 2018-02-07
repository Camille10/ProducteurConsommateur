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
    public class CommunicateQueueTests
    {
        private int maxElements = 1000;
        CommunicateQueue queueToProduceAndSort = new CommunicateQueue(maxElements);
        Random ramdomNumberGenerator = new Random();

        [TestMethod()]
        public void should_add_element_into_queue()
        {
            Assert.IsTrue(queueToProduceAndSort.Enqueue(ramdomNumberGenerator.Next()));
        }

        [TestMethod()]
        public void should_be_finished_when_queue_is_full()
        {
            for (int index = 0; index < maxElements; index++)
            {
                Assert.IsTrue(queueToProduceAndSort.Enqueue(ramdomNumberGenerator.Next()));
            }
            Assert.IsTrue(queueToProduceAndSort.IsFinished);
        }

    }
}
