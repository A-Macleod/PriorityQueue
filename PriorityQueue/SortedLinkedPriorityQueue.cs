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
            // https://runestone.academy/ns/books/published/cppds/LinearLinked/ImplementinganOrderedList.html

            Node<T> newNode = new Node<T>(item, priority);

            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                Node<T> currentNode = _head;
                Node<T> previous = null;

                // If newNode Priority is greater than the _head, insert newNode at the _head
                //if (newNode.Priority > currentNode.Priority)
                //{
                //    newNode.Next = _head;
                //    _head = newNode;
                //}

                if ( newNode.Priority > _head.Priority || _head == null)
                {
                    newNode.Next = _head;
                    _head = newNode;
                }
                else
                {
                    // Loop through each Node in the SortedLinkedList
                    while (currentNode != null)
                    {
                        
                        // If the current looped node is greater than the newNode Prio
                        if (currentNode.Priority > newNode.Priority)
                        {
                            newNode.Next = currentNode; // set the next pointer to this current looped node
                            previous.Next = newNode;
                            return;                     // break the loop
                        }
                        else
                        {
                            previous = currentNode;         // record this node as the previous node
                            currentNode = currentNode.Next; // Move to next Node
                        }
                    }
                }



                 



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


        //public override string ToString()
        //{
        //}



    }
}
