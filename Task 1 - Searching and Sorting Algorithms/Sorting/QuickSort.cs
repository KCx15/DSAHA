using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// Class allowing the sorting of Order objects based on based on Order ID (ascending order) 
    /// using Quick Sort where the pivot is the left-most element
    /// 
    /// TODO: You are to implement the Sort() method for this class; additional methods may be added but:
    /// 1. The final result i.e. the sorted array of orders must be returned by the Sort() method provided
    /// 2. Any methods added to this class must be declared as private and called within the Sort() method
    /// </summary>
    internal class QuickSort : Sorter
    {
        public override List<Order> Sort(List<Order> orders)
        {
            List<Order> clone = new List<Order>(orders);
            QuickSortHelper(clone, 0, clone.Count - 1);
            return clone;
        }

        private void QuickSortHelper(List<Order> orders, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(orders, low, high);
                QuickSortHelper(orders, low, pivotIndex - 1);
                QuickSortHelper(orders, pivotIndex + 1, high);
            }
        }

        private int Partition(List<Order> orders, int low, int high)
        {
           
            Order pivot = orders[low];
            int left = low + 1;
            int right = high;

            while (left <= right)
            {
                while (left <= right && orders[left].ID.CompareTo(pivot.ID) <= 0)
                    left++;

                while (left <= right && orders[right].ID.CompareTo(pivot.ID) > 0)
                    right--;

                if (left < right)
                    Swap(orders, left, right);
            }

            Swap(orders, low, right); 
            return right;
        }

        private void Swap(List<Order> orders, int i, int j)
        {
            Order temp = orders[i];
            orders[i] = orders[j];
            orders[j] = temp;
        }
    }

}
