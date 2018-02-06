using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ProducteurConsommateur.Tests
{
    [TestClass()]
    public class ConsommateurTests
    {
        private OutputList sortedList = new OutputList();
        private LinkedList<int> c = new LinkedList<int>();
        CommunicationQueue cqueue = new CommunicationQueue(nbElement);
        Consommateur consommateur;
        private static int nbElement = 1000;

        public ConsommateurTests()
        {
            consommateur = new Consommateur(cqueue, sortedList);
        }

        [TestMethod]
        public void Should_be_remove_in_queue()
        {
            Random _rnd = new Random();
            for (int _index = 0; _index < nbElement; _index++)
            {
                cqueue.Enqueue(_rnd.Next());
            }
            consommateur.Run();
            while (!(cqueue.IsFinished && cqueue.IsEmpty)) { }
            Assert.AreEqual(cqueue.IsFinished, true);
        }
    }
}
