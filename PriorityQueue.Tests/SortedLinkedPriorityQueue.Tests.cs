using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace PriorityQueue.Tests
{
    public class SortedLinkedPriorityQueue
    {

        private SortedLinkedPriorityQueue<Person> sortedLinkedPriorityQueue;



        [SetUp]
        public void Setup()
        {
            sortedLinkedPriorityQueue = new SortedLinkedPriorityQueue<Person>();
        }



        [TearDown]
        public void TearDown()
        {
            sortedLinkedPriorityQueue = null;
        }































    }
}
