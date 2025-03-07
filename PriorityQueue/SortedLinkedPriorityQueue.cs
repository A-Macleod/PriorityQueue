using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class SortedLinkedPriorityQueue<T> : PriorityQueue<T> 
    {

        private Node<T> _head;


        public SortedLinkedPriorityQueue()
        {
            _head = null;
        }


        /// <summary>
        /// SortedLinkedList method to return the name of the HighestPriority Item. The Highest Priority
        /// Item should always be at the _Head of the queue as we sort the Nodes in their correct space
        /// during the Enqueue operation.
        /// </summary>
        /// <returns>Highest Priorty Item Name</returns>
        /// <exception cref="QueueUnderflowException"></exception>
        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            return _head.Item;
        }


        /// <summary>
        /// SortedLinkedList method to add an Item with its Priority into the correct position in the LinkedList. If the newNodes Priority is greater than
        /// the _heads Priority, make the newNode the _head. If not, search through the Nodes to find the correct position for the newNode and update the 
        /// Next pointers
        /// </summary>
        /// <param name="item">Generic, Name of Item</param>
        /// <param name="priority">Integer, Priority of Item</param>
        public void Add(T item, int priority)
        {

            Node<T> newNode = new Node<T>(item, priority);

            if (_head == null || newNode.Priority > _head.Priority)
            {
                newNode.Next = _head;
                _head = newNode;
            }
            else
            {

                /* 
                * Starting at the _head Node and while there is a next Node and while the next Nodes Priority is greater or equal to the newNode Priority, traverse the LinkedList. 
                * When we find the Node in the LinkedList that its Next Priority is LESS than the newNode, stop traversing, update currentNode to this found node.
                *      [HEAD 70]-[50]-[45]-[30]   [NEWNODE 40] 
                *                      ^
                * Point the newNode to the currentNodes Next pointer.  [NEWNODE]-[30]
                * Point the currentNodes Next pointer to the newNode.  [45]-[NEWNODE 40]
                * We have now inserted the newNode in the correct positon while maintaining the FIFO Priority Queue
                *      [HEAD 70]-[50]-[45]-[40]-[30]
                */

                Node<T> currentNode = _head;
                while (currentNode.Next != null && currentNode.Next.Priority >= newNode.Priority)
                {
                    currentNode = currentNode.Next;
                }

                newNode.Next = currentNode.Next;
                currentNode.Next = newNode;
            }
        }


        public void Remove()
        {
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


        /// <summary>
        /// Method to override the ToString method and throw an exception if there is no Nodes created.
        /// Traverses the LinkedList and repeatedly adds each Nodes Item and Priority to the result string variable.
        /// Returns each Nodes value in the LinkedList, the Item and Priority. Seperated by a comma in a braket wrapper.
        /// </summary>
        /// <returns>Each Nodes Item and Priority</returns>
        /// <exception cref="QueueUnderflowException"></exception>
        public override string ToString()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("No items to display");
            }

            Node<T> currentNode = _head;
            string result = "[";

            while (currentNode != null)     // Keep traversing until the end of the LinkedList
            {
                if (currentNode != _head)   // Seperate results after _head with a comma
                {
                    result += ", ";
                }
                result += $"({currentNode.Item},{currentNode.Priority})";   // Add on the Item and Priority of the Node to the result variable
                currentNode = currentNode.Next;                             // Move to the Next Node
            }
            result += "]";                  // Add a square bracket to the end
            return result;                  // Return the concatenated result
        }
    }
}
