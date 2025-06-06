using DSA___A2___Part_Soution;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of the PRNG
        SplitMix64 prng = new SplitMix64();

        // B. Empirical Analysis for Intractability
        Console.WriteLine("\nEmpirical Analysis for Intractability:");
        Console.WriteLine("-------------------------------------");

        // Test cases with different sizes
        int[] testSizes = { 1000, 10000, 100000, 1000000 };
        var timingResults = new List<(int Size, double Milliseconds)>();

        foreach (int size in testSizes)
        {
           
            prng.Next(1, 1000);

            // Start timing
            Stopwatch sw = Stopwatch.StartNew();

            // Generate the required number of random numbers
            for (int i = 0; i < size; i++)
            {
                prng.Next(1, 1000);
            }

            // Stop timing
            sw.Stop();

            // Store results
            double elapsedMs = sw.Elapsed.TotalMilliseconds;
            timingResults.Add((size, elapsedMs));

            Console.WriteLine($"Generated {size,7} numbers in {elapsedMs,8:F2} ms");
        }

        // Display results in a table format
        Console.WriteLine("\nTiming Results Table:");
        Console.WriteLine("Size      | Time (ms)");
        Console.WriteLine("----------|----------");
        foreach (var result in timingResults)
        {
            Console.WriteLine($"{result.Size,8} | {result.Milliseconds,8:F2}");
        }

   
    }
}