using System;
using System.Collections.Generic;
using Task_1___Searching_and_Sorting_Algorithms;

#pragma warning disable CS7022 
internal class Program
{
    private static void Main(string[] args)
    {
        OrderManager orderManager = new OrderManager();
        int choice = 0;

        do
        {
            Console.Clear();
            Console.WriteLine("Choose an Option:");
            Console.WriteLine("1. View Orders");
            Console.WriteLine("2. Search Orders");
            Console.WriteLine("3. View Most Urgent Orders");
            Console.WriteLine("4. Exit");
            Console.Write("Choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("\nInvalid input. Please enter a number between 1 and 4.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nSelect a Sorting Option:");
                    Console.WriteLine("1. View Orders sorted by ID");
                    Console.WriteLine("2. View Orders sorted by Placed On Date");
                    Console.WriteLine("3. View Orders sorted by Delivery Date");
                    Console.Write("Choice: ");

                    if (int.TryParse(Console.ReadLine(), out int sortChoice) && sortChoice >= 1 && sortChoice <= 3)
                    {
                        List<Order> sortedOrders = orderManager.SortOrders(sortChoice);
                        Console.WriteLine($"\nTotal Orders Found: {sortedOrders.Count}\n");

                        foreach (Order order in sortedOrders)
                        {
                            Console.WriteLine(order);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid sort choice.");
                    }

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;

                case 2:
                    Console.Write("\nEnter Order ID: ");
                    string orderID = Console.ReadLine();
                    Order orderFound = orderManager.GetOrderByID(orderID);

                    if (orderFound != null)
                    {
                        Console.WriteLine("\nOrder Found:");
                        Console.WriteLine(orderFound);
                    }
                    else
                    {
                        Console.WriteLine($"\nNo Order Found Matching ID: {orderID}");
                    }

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;

                case 3:
                    Console.WriteLine("\nListing 5 Most Urgent Orders:\n");
                    List<Order> urgentOrders = orderManager.GetMosturgentOrders();

                    foreach (Order urgent in urgentOrders)
                    {
                        Console.WriteLine(urgent);
                    }

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;

                case 4:
                    Console.WriteLine("\nExiting the program...");
                    break;

                default:
                    Console.WriteLine("\nInvalid Option Selected.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }

        } while (choice != 4);
    }
}
