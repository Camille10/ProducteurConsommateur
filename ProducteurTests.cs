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
            producteur = new Producteur(cqueue);
        }
    
        [TestMethod]
        public void Should_be_fill_the_queue()
        {
        producteur.Run();
        while (!cqueue.IsFinished){}
        Assert.AreEqual(true, cqueue.IsFinished);
        }
    }
    
}
