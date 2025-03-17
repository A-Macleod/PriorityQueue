using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace PriorityQueue.Tests
{
    public class UnsortedLinkedPriorityQueue
    {

        private UnsortedLinkedPriorityQueue<Person> unsortedLinkedPriorityQueue;



        [SetUp]
        public void Setup()
        {
            unsortedLinkedPriorityQueue = new UnsortedLinkedPriorityQueue<Person>();
        }



        [TearDown]
        public void TearDown()
        {
            unsortedLinkedPriorityQueue = null;
        }























    }
}
