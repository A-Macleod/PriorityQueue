﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace PriorityQueue.Tests
{
    public class UnsortedArrayPriorityQueueTests
    {

        private UnsortedArrayPriorityQueue<Person> UnsortedArrayPriorityQueue;



        [SetUp]
        public void Setup()
        {
            int size = 8;
            UnsortedArrayPriorityQueue = new UnsortedArrayPriorityQueue<Person>(size);
        }





















    }
}
