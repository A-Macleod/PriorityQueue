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
        private readonly T _data;
        private readonly int _priority;
        private Node<T> _head;

        public UnsortedLinkedPriorityQueue()
        {
            _head = null;
        }


        /// <summary>
        /// UnsortedLinkedList method to create a newNode object with a generic data argument and priority.
        /// Point newNode pointer to the current head, Update the head to point to the newNode.
        /// This will add a newNode to the end of the LinkedList, without sorting, and pointing it to the
        /// Node below it.
        /// </summary>
        /// <param name="data">Generic data type</param>
        /// <param name="priority">Priority of data</param>
        public void Add(T data, int priority)
        {
            Node<T> newNode = new Node<T>(data, priority);  // create new node
            newNode.Next = _head;                           // point it to the current head
            _head = newNode;                                // update the head to point to the new node (start point) 

        }


        /// <summary>
        /// UnsortedLinkedList method to remove the Node with the Highest Priority by changing the Previous Nodes Pointer
        /// to the Node after the Highest Priority Node. If there is no Nodes, throw exception error. Traverse the LinkedList 
        /// searching for the Node with the Highest Priority, while comparing the Priority value against the Next node. 
        /// Remove the HighestPriorityNode by changing the Pointers.  
        /// </summary>
        /// <exception cref="QueueUnderflowException">Exception error. There is no Nodes</exception>
        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            Node<T> currentNode = _head;
            Node<T> highestPriorityNode = _head;
            Node<T> previousNode = null;

            // Traverse the LinkedList to find the Node with the Highest Priority, starting at the Head Node
            while (currentNode != null)
            {
                if (currentNode.Priority > highestPriorityNode.Priority)    // Compare values
                {
                    highestPriorityNode = currentNode;                      // Update the new Highest Priority Node 
                    previousNode = currentNode;
                }
                currentNode = currentNode.Next;                             // Move to the next Node
            }


            /* Removing the Highest Priority Node.
            /  This jumps the link over the HighestPriorityNode because we change the Pointers,
            /  we link the Previous Node to the one AFTER the HighestPriority using the
            /  HighestPriorityNodes Next Pointer.   [Previous] [HighestPrio] [HighestPrioNext]
            /                                           |____________________________|      
            */
            if (highestPriorityNode == _head)   // If the Node to be removed is the head
            {
                _head = _head.Next;             // Change the pointer of the head to the next Node in the LinkedList
            }
            else
            {
                previousNode.Next = highestPriorityNode.Next;   // Change the PreviousNodes Pointer to HighestPriorityNodes Next Pointer.
            }  
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
