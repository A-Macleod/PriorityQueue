using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{

    /// <summary>
    /// Class to represent an unsorted, array based, priority queue.
    /// Inheriting members from the PriorityQueue Interface.
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    class UnsortedArrayPriorityQueue<T> : PriorityQueue<T>
    {

        /// <summary>
        /// Private fields for unsorted array priority queue
        /// </summary>
        private readonly PriorityItem<T>[] _storage;
        private readonly int _capacity;
        private int _tailIndex;


        /// <summary>
        /// Constructor for unsorted array priority queue that takes in a size arguement
        /// to determine the size of the array we want to create
        /// </summary>
        /// <param name="size">The array size</param>
        public UnsortedArrayPriorityQueue(int size)
        {
            _storage = new PriorityItem<T>[size]; 
            _capacity = size;
            _tailIndex = -1;
        }
    }
}
