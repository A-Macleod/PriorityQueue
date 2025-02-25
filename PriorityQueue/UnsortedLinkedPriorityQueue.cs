using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PriorityQueue
{
    public class UnsortedLinkedPriorityQueue<T> : PriorityQueue<T> 
    {
        private T _data;
        private int _priority;
        private Node<T> _head;

        public UnsortedLinkedPriorityQueue()
        {
            _head = null;
        }


        public void Add(T data, int priority)
        {
            Node<T> newNode = new Node<T>(data, priority);  // create new node
            newNode.Next = _head;                           // point it to the current head
            _head = newNode;                                // update the head to point to the new node (start point) 

        }








        /// <summary>
        /// Method to return True if the head does not exist, meaning, if there is No Nodes created.
        /// Otherwise, return False. 
        /// </summary>
        /// <returns>True if the _head does NOT contain a Node</returns>
        public bool IsEmpty()
        {
            return _head == null;
        }









    }
}
