using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProducteurConsommateur.Tests
{
    [TestClass()]
    public class OutputListTests
    {
        public OutputList OutputListClass = new OutputList();

        [TestMethod()]
        public void should_be_add_in_sortedList()
        {
            Random randomNumber = new Random();
            int number = randomNumber.Next();
            OutputListClass.Add(number, number);
            Assert.AreEqual(OutputListClass.outputList.Count, 1);
        }

    }
}
