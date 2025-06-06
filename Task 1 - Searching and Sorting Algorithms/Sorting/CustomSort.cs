﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class CustomSort : Sorter
    {
        public override List<Order> Sort(List<Order> orders)
        {
            return orders.OrderByDescending(o => o.deliverOn).ToList();
        }
    }

}
