using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace PriorityQueue
{
    /// <summary>
    /// Class to represent an unsorted, linked list, priority queue. The Nodes are not 
    /// linked or sorted in order of priority. The queue maintains the First In First Out
    /// data structure. Traversing each node is needed to find the highest priority node for 
    /// the dequeue, peek and ToString methods. Highest Priority is determined by the highest or 
    /// largest integer number in the Priority field.
    /// </summary>
    /// <typeparam name="T">Generic data type</typeparam>
    public class UnsortedLinkedPriorityQueue<T> : PriorityQueue<T> 
    {

        private Node<T> _head;


        /// <summary>
        /// Constructor for unsorted linked priority queue. Initializes the queue with the _head as null 
        /// </summary>
        public UnsortedLinkedPriorityQueue()
        {
            _head = null;
        }


        /// <summary>
        /// UnsortedLinkedList method to return the name of the HighestPriority Item. Checking if the PriorityQueue
        /// is empty and if so, throwing an exception error. Traverses the LinkedList checking each Node for the Node
        /// with the HighestPriority. 
        /// </summary>
        /// <returns>Highest Priorty Item Name</returns>
        /// <exception cref="QueueUnderflowException"></exception>
        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }

            Node<T> currentNode = _head;
            Node<T> highestPriorityNode = _head;

            // Traverse the LinkedList to find the Node with the Highest Priority, starting at the Head Node
            while (currentNode != null)
            {
                if (currentNode.Priority > highestPriorityNode.Priority)    
                {
                    highestPriorityNode = currentNode;                      // Update the new Highest Priority Node 
                }
                currentNode = currentNode.Next;                             // Move to the next Node
            }
            return highestPriorityNode.Item;
        }


        /// <summary>
        /// UnsortedLinkedList method to create a newNode object with a generic item argument and integer priority.
        /// Traverse the LinkedList until the end Node. Set the end Node Next pointer to this newNode. 
        /// This will add the newNode to the end of the LinkedList. This will maintain the LIFO order of the LinkedList
        /// while also being Unsorted.
        /// </summary>
        /// <param name="item">Generic item type</param>
        /// <param name="priority">Priority of item</param>
        public void Add(T item, int priority)
        {
            Node<T> newNode = new Node<T>(item, priority);  

            if (_head == null)                              
            {
                _head = newNode;
            }
            else
            {
                // [(1,80) (2, 90) (3, 100)] FIFO
                Node<T> currentNode = _head;
                while (currentNode.Next != null)    
                {
                    currentNode = currentNode.Next; // Traverse the LinkedList
                }
                currentNode.Next = newNode;         // At the last Node of the LinkedList (with the NULL pointer) change its Next Pointer to
                                                    // point to the newly created Node, adding the newNode to the end of the LinkedList

                // [(3,100) (2, 90) (1, 80)] LIFO
                //newNode.Next = _head;
                //_head = newNode;
            }
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

            int count = 0;
            int highestPriorityCount = 0;

            // Find HighestPriority Node while traversing each node, recording the count of the Nodes and the Index of the HighestPriorityNode
            while (currentNode != null)
            {
                count++;                            // Increment count

                if (currentNode.Priority > highestPriorityNode.Priority)
                {
                    highestPriorityNode = currentNode;
                    highestPriorityCount = count;   // This is the Index of the Highest Priority Node
                }
                
                currentNode = currentNode.Next;     // Move to next Node
            }


            // Loop to find the PreviousNode to the HighestPriorityNode 
            currentNode = _head;                // Reset the currentNode to the start of the LinkedList again, because of the While loop
            for (int i = 1; currentNode != null; i++)
            {
                if (i == highestPriorityCount - 1)
                {
                    previousNode = currentNode; // This is the previousNode to the HighestPriorityNode
                    break;
                }

                currentNode = currentNode.Next; // Move to next node
            }


            // Remove HighestPriorityNode from LinkedList
            if (highestPriorityNode == _head)
            {
                _head = _head.Next;
            }
            else
            {
                previousNode.Next = highestPriorityNode.Next;
            }

            //Node<T> currentNode = _head;
            //Node<T> highestPriorityNode = _head;
            //Node<T> previous = null;
            //Node<T> previousNode = null;


            //        // Traverse the LinkedList to find the Node with the Highest Priority, starting at the Head Node
            //        while (currentNode != null)
            //        {
            //            if (currentNode.Priority > highestPriorityNode.Priority)    // If the CurrentNode Priority is greater than the record of the highestPriorityNode
            //            {
            //                highestPriorityNode = currentNode;                      // Highest Priority Node is this currentNode, since the currentNode has the higher Priority value   
            //                previousNode = previous;                                // Update the Previous Node, which will be the previous from the outer loop
            //            }
            //            previous = currentNode;                                     // Previous is the currentNode
            //            currentNode = currentNode.Next;                             // Move to the next Node
            //        }
            //    /*
            //    * Removing the Highest Priority Node.
            //    *  This jumps the link over the HighestPriorityNode because we change the Pointers,
            //    *  we link the PreviousNode to the one AFTER the HighestPriority using the
            //    *  HighestPriorityNodes Next Pointer.   [Previous] [HighestPrio] [HighestPrioNext]
            //    *                                           |____________________________|      
            //    */
            //    if (highestPriorityNode == _head)   // If the Node to be removed is the head
            //    {
            //        _head = _head.Next;             // Change the pointer of the head to the next Node in the LinkedList, this will remove the head node from the LinkedList
            //    }
            //    else
            //    {
            //        previousNode.Next = highestPriorityNode.Next;   // Change the PreviousNodes Pointer to HighestPriorityNodes Next Pointer.  
            //    }
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

            while (currentNode != null)     
            {
                if (currentNode != _head)   
                {
                    result += ", ";
                }
                result += $"({currentNode.Item}" + ", " + $"{currentNode.Priority})";   
                currentNode = currentNode.Next;                             
            }
            result += "]";                  
            return result;                  
        }
    }
}
