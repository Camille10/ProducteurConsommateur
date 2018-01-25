using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProducteurConsommateur.Tests
{
    [TestClass()]
    public class SortedListOutputTests
    {
        public SortedListOutput sortedListClass = new SortedListOutput();


        [TestMethod()]
        public void should_be_add_in_sortedList()
        {
            Random randomNumber = new Random();
            int number = randomNumber.Next();
            sortedListClass.Add(number, number);
            Assert.AreEqual(sortedListClass.sortedList.Count, 1);
        }
    }
}