using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// Abstract class acting as parent class for all classes reflecting sorting algorithms
    /// This class requires no further modification
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal abstract class Sorter
    {
        public abstract List<Order> Sort(List<Order> orders);
    }

}
