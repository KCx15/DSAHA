using System.Collections.Generic;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class PriorityQueue
    {
        private Heap heap;

        public PriorityQueue()
        {
            heap = new Heap();
        }

        // Build heap from list of orders (O(n log n))
        public void Build(List<Order> orders)
        {
            foreach (var order in orders)
            {
                heap.Insert(order); // O(log n) per insert
            }
        }

        // Retrieve 5 most urgent orders (O(log n) each removal)
        public List<Order> GetMostUrgentOrders(List<Order> orders)
        {
            Build(orders); // Fill the heap

            List<Order> urgentOrders = new List<Order>();

            for (int i = 0; i < 5 && heap.Count > 0; i++)
            {
                urgentOrders.Add(heap.Remove());
            }

            return urgentOrders;
        }
    }
}
