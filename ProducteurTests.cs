using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProducteurConsommateur.Tests
{
    [TestClass()]
    public class ProducteurTests
    {
        Producteur producteur;
        QueueToProduceAndSort cqueue;
        private static int nbElement = 1000;

        public ProducteurTests()
        {
            cqueue = new QueueToProduceAndSort(nbElement);
            producteur = new Producteur(cqueue, nbElement);
        }

        [TestMethod()]
        public void ShouldAddElementInCQueue()
        {
            producteur.Run();
            while (!producteur.IsFinish) { }
            Assert.AreEqual(nbElement, cqueue.ConcurrentQueue.Count);
        }
    }
}