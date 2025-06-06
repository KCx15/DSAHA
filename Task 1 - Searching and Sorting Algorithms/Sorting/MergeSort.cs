using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// Class allowing the sorting of Order objects based on Date Placed (most recent first) using Merge Sort
    /// 
    /// TODO: You are to implement the Sort() method for this class; additional methods may be added but:
    /// 1. The final result i.e. the sorted array of orders must be returned by the Sort() method provided
    /// 2. Any methods added to this class must be declared as private and called within the Sort() method
    /// </summary>
    internal class MergeSort : Sorter
    {
        public override List<Order> Sort(List<Order> orders)
        {
            return MergeSortHelper(new List<Order>(orders));
        }

        private List<Order> MergeSortHelper(List<Order> orders)
        {
            if (orders.Count <= 1)
                return orders;

            int mid = orders.Count / 2;
            List<Order> left = MergeSortHelper(orders.GetRange(0, mid));
            List<Order> right = MergeSortHelper(orders.GetRange(mid, orders.Count - mid));

            return Merge(left, right);
        }

        private List<Order> Merge(List<Order> left, List<Order> right)
        {
            List<Order> result = new List<Order>();
            int i = 0, j = 0;

            while (i < left.Count && j < right.Count)
            {
                
                if (left[i].placedOn >= right[j].placedOn)
                    result.Add(left[i++]);
                else
                    result.Add(right[j++]);
            }

            while (i < left.Count)
                result.Add(left[i++]);

            while (j < right.Count)
                result.Add(right[j++]);

            return result;
        }
    }

}
