using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// Class used to build the Heap serving as the underlying data structure for the Priority Queue required to
    /// get the most urgent orders i.e. the ones with the soonest deliver date
    /// 
    /// TODO: You are to determine whether this Heap should be a MinHeap or a MaxHeap 
    /// based on the way that urgent orders need to be identified i.e. soonest delivery date first.
    /// Implement the Insert() and Remove() method for this class; additional methods may be added but these 
    /// must be declared as private and called within the Insert() or Remove() method
    /// </summary>
    internal class Heap
    {
        private List<Order> heap;

        public Heap()
        {
            heap = new List<Order>();
        }

        public void Insert(Order order)
        {
            heap.Add(order);
            HeapifyUp(heap.Count - 1);
        }

        public Order Remove()
        {
            if (heap.Count == 0) return null;

            Order root = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);

            return root;
        }

        public int Count => heap.Count;

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;

                if (heap[index].deliverOn >= heap[parentIndex].deliverOn)
                    break;

                Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        private void HeapifyDown(int index)
        {
            int smallest = index;

            while (true)
            {
                int left = 2 * index + 1;
                int right = 2 * index + 2;

                if (left < heap.Count && heap[left].deliverOn < heap[smallest].deliverOn)
                    smallest = left;

                if (right < heap.Count && heap[right].deliverOn < heap[smallest].deliverOn)
                    smallest = right;

                if (smallest == index)
                    break;

                Swap(index, smallest);
                index = smallest;
            }
        }

        private void Swap(int i, int j)
        {
            Order temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }

}
