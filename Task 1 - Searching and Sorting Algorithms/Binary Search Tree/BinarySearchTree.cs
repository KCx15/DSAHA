using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class BinarySearchTree
    {
        private class Node
        {
            public Order Order;
            public Node Left;
            public Node Right;

            public Node(Order order)
            {
                Order = order;
                Left = null;
                Right = null;
            }
        }

        private Node root;

        public void Build(List<Order> orders)
        {
            if (orders == null || orders.Count == 0)
                return;

            root = new Node(orders[0]); // First element as root

            for (int i = 1; i < orders.Count; i++)
            {
                Insert(root, orders[i]);
            }
        }

        private void Insert(Node current, Order order)
        {
            if (order.ID.CompareTo(current.Order.ID) < 0)
            {
                if (current.Left == null)
                    current.Left = new Node(order);
                else
                    Insert(current.Left, order);
            }
            else
            {
                if (current.Right == null)
                    current.Right = new Node(order);
                else
                    Insert(current.Right, order);
            }
        }

        public Order Get(Guid orderID)
        {
            return Search(root, orderID);
        }

        private Order Search(Node current, Guid id)
        {
            if (current == null)
                return null;

            int comparison = id.CompareTo(current.Order.ID);

            if (comparison == 0)
                return current.Order;
            else if (comparison < 0)
                return Search(current.Left, id);
            else
                return Search(current.Right, id);
        }
    }
}

