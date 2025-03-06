using System;

namespace PriorityQueue
{
    /// <summary>
    /// Class to represent a sorted, array based, priority queue.
    /// Inheriting members from the PriorityQueue Interface.
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    public class SortedArrayPriorityQueue<T> : PriorityQueue<T>
    {

        /// <summary>
        /// Private fields for sorted array priority queue
        /// </summary>
        private readonly PriorityItem<T>[] storage;
        private readonly int capacity;
        private int tailIndex;


        /// <summary>
        /// Constructor for sorted array priority queue that takes in a size argument
        /// to determine the size of the array we want to create
        /// </summary>
        /// <param name="size">The array size</param>
        public SortedArrayPriorityQueue(int size)
        {
            storage = new PriorityItem<T>[size];
            capacity = size;
            tailIndex = -1;
        }


        /// <summary>
        /// Method to return the head of the array, at index 0, the Item name.
        /// This is the item with Highest Priority.
        /// </summary>
        /// <returns>Array index position 0, the person name</returns>
        /// <exception cref="QueueUnderflowException"></exception>
        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            return storage[0].Item;
        }


        /// <summary>
        /// Method to add an item and priority to the sorted array priority queue. Increments
        /// the tailIndex by 1 and checks if the size of the array is greater or equal to the
        /// capacity. If so, throws an exception. Starting at the tail index, check if the previous 
        /// Index priority is less than the incoming priority, if so move lower priority item (previous) to the right.
        /// The new PriorityItem is now inserted into this space. 
        /// </summary>
        /// <param name="item">The name of the person</param>
        /// <param name="priority">The priority of the person</param>
        /// <exception cref="QueueOverflowException"></exception>
        public void Add(T item, int priority)
        {
            tailIndex++;
            if (tailIndex >= capacity)
            {
                tailIndex--;
                throw new QueueOverflowException();
            }

            int i = tailIndex;
            while (i > 0 && storage[i - 1].Priority < priority)
            {
                storage[i] = storage[i - 1];
                i--;
            }
            storage[i] = new PriorityItem<T>(item, priority);
        }


        /// <summary>
        /// Method to remove the Highest Priority item at Index 0.
        /// Check if array tailIndex is less than 0. If so thow UnderflowException.
        /// Iterates through the array and copys and moves each Index one to the left. Then
        /// decrements the tailIndex
        /// </summary>
        /// <exception cref="QueueUnderflowException"></exception>
        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            for (int i = 0; i < tailIndex; i++)
            {
                storage[i] = storage[i + 1];
            }
            tailIndex--;
        }


        /// <summary>
        /// Method to return true if the tailIndex is less than 0. This shows us the array is empty
        /// as each newly added item increases the tail by 1 index. The first item in the array will be index 0,
        /// as the array is created with a default index of -1
        /// </summary>
        /// <returns>True if the tail index is less than 0</returns>
        public bool IsEmpty()
        {
            return tailIndex < 0;
        }


        /// <summary>
        /// Method to override the ToString method and throw an exception if the array is empty (tailIndex is less than 0).
        /// Adds a bracket infront and after each returned array index value, seperated by an added comma in the nested loop.
        /// Returns each index value in the array, the Item and Priority.
        /// </summary>
        /// <returns>Array index value</returns>
        /// <exception cref="QueueUnderflowException"></exception>
        public override string ToString()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("No items to display");
            }

            string result = "[";
            for (int i = 0; i <= tailIndex; i++)
            {
                if (i > 0)
                {
                    result += ", ";
                }
                result += storage[i];
            }
            result += "]";
            return result;
        }
    }
}
