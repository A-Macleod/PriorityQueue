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


        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            return _head.Item;
        }


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
                Node<T> currentNode = _head;

                while (currentNode.Next != null && currentNode.Next.Priority >= newNode.Priority)
                {
                    currentNode = currentNode.Next;
                }

                newNode.Next = currentNode.Next;
                currentNode.Next = newNode;

            }




                // If newNode Priority is greater than the _head, insert newNode at the _head
                //if (newNode.Priority > currentNode.Priority)
                //{
                //    newNode.Next = _head;
                //    _head = newNode;
                //}


                // Loop through each Node in the SortedLinkedList
                //while (currentNode != null)
                //{

                //    // If the current looped node is greater than the newNode Prio
                //    if (currentNode.Priority > newNode.Priority)
                //    {
                //        newNode.Next = currentNode; // set the next pointer to this current looped node
                //        previousNode = previous;
                //        return;                     // break the loop
                //    }
                //    else
                //    {
                //        previous = currentNode;         // record this node as the previous node
                //        currentNode = currentNode.Next; // Move to next Node
                //    }
                //}   

            

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
