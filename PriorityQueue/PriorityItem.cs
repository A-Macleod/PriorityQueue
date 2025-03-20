namespace PriorityQueue
{
    /// <summary>
    /// A class to represent a generic Item and Priority in the Priority Queue
    /// </summary>
    /// <typeparam name="T">Generic data type</typeparam>
    public class PriorityItem<T>
    {
        public T Item { get; }
        public int Priority { get; }

        /// <summary>
        /// Constructor to instantiate the Priority Item with an Item and a Priority 
        /// </summary>
        /// <param name="item">Name of Object</param>
        /// <param name="priority">Priority of Object</param>
        public PriorityItem(T item, int priority)
        {
            Item = item;
            Priority = priority;
        }

        /// <summary>
        /// Method to return the Item and Priority
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"({Item}, {Priority})";
        }
    }
}
