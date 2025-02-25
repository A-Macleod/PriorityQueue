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
        public T Data { get; set; }
        public int Priority { get; set; }
        public Node<T> Next { get; set; }


        /// <summary>
        /// Node constructor for the Node class. It will store the generic type Data, the 
        /// Priority and the Pointer to the Next Node
        /// </summary>
        /// <param name="data">The name of the person</param>
        /// <param name="priority">The priority of the person</param>
        /// <param name="next">The pointer to the Next Node</param>
        public Node(T data, int priority, Node<T> next)
        {
            Data = data;
            Priority = priority;
            Next = null;
        }
    }
}
