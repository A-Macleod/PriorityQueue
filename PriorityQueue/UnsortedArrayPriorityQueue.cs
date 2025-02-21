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


        /// <summary>
        /// Method to return the Highest Priority Item in the array. Check if the array is empty,
        /// if so, throw an exception error. Loop through the array and find the index with the highest
        /// Priority value and save that index number into highestPriorityIndex. Return that indexes Item from the array
        /// </summary>
        /// <returns>The index of the Item with the highest Priority in the array</returns>
        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            int highestPriorityIndex = 0;
            for (int i = 0; i <= _tailIndex; i++)
            {
                if (_storage[i].Priority > _storage[highestPriorityIndex].Priority)
                {
                    highestPriorityIndex = i;
                }
            }
            return _storage[highestPriorityIndex].Item;
        }


        /// <summary>
        /// Method to add an item and priority to the unsorted array priority queue.
        /// Check if the tailIndex is greater than the array size, if so, throw exception error.
        /// Increment the tailIndex and insert the new PriorityItem into that position. 
        /// </summary>
        /// <param name="item">the item name</param>
        /// <param name="priority">the priority of the item</param>
        public void Add(T item, int priority)
        {
            _tailIndex++;
            if (_tailIndex >= _capacity)
            {
                _tailIndex--;
                throw new QueueOverflowException();
            }
            _storage[_tailIndex] = new PriorityItem<T>(item, priority);
        }

        /// <summary>
        /// Method to remove the Item with the Highest Priority from the array, then shift each element afterwards
        /// down one position. Check if the array IsEmpty, if so, throw UnderflowException error. Find the Index with
        /// the Highest Priority. Looping from the Highest Priority Index, shift each Index down one position. Decreasing 
        /// the tail Index by 1. 
        /// </summary>
        /// <exception cref="QueueUnderflowException"></exception>
        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            int highestPriorityIndex = 0;
            for(int i = 0; i <= _tailIndex; i++)
            {
                if (_storage[i].Priority > _storage[highestPriorityIndex].Priority)
                {
                    highestPriorityIndex = i;
                }
            }

            for(int i = highestPriorityIndex; i <= _tailIndex; i++)
            {
                _storage[i] = _storage[i + 1];
            }

            _tailIndex--;

            // check if array is empty, throw exception if so
            // linear search for highest priority item in the array
            // remove the item, then shift the array indexs down one position
            // decrease tail index by 1
  
        }


        /// <summary>
        /// Method to return true or false if the tailIndex is less than 0. This shows us the array is empty
        /// as each newly added item increases the tail by 1 index. The first item will be index 0.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _tailIndex < 0;
        }


        //string ToString() 
        //{ 
        //}
    }
}
