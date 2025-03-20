using PriorityQueue;

namespace PriorityQueue
{
    /// <summary>
    /// A class to represent a Person in the priority queue implementation
    /// </summary>
    public class Person
    {
        public string Name { get; }

        /// <summary>
        /// Constructor for te Person class. It will instantate a Person with a name
        /// </summary>
        /// <param name="name">Name of the Person</param>
        public Person(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Method to return the Name of the Person
        /// </summary>
        /// <returns>Name of Person</returns>
        public override string ToString()
        {
            return Name;
        }
    }

}
