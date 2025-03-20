using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    /// <summary>
    /// Node class, represents a node in the Linked List Priority Queue. Stores the information
    /// for each Node; the Data, Priority and the Pointer to the Next Node. On instantiation of a new Node,
    /// the "Next Node" will be set to Null. 
    /// </summary>
    /// <typeparam name="T">Generic data type</typeparam>
    public class Node<T>
    {

        /// <summary>
        /// Private fields for Node class with auto properties to get and set the fields
        /// </summary>
        public T Item { get; set; }
        public int Priority { get; set; }
        public Node<T> Next { get; set; }


        /// <summary>
        /// Constructor for the Node class. It will store the generic type Item, the 
        /// Priority and the Pointer to the Next Node
        /// </summary>
        /// <param name="item">The name of the person</param>
        /// <param name="priority">The priority of the person</param>
        /// <param name="Next">The pointer to the Next Node</param>
        public Node(T item, int priority)
        {
            Item = item;
            Priority = priority;
            Next = null;
        }
    }
}
