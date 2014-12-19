using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class CountingPrimes
{
    static void Main(string[] args)
    {
        using (StreamReader reader = File.OpenText(args[0]))
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                    continue;
                // code here

                int[] input = line.Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                int n = input.Min();
                int m = input.Max()+1;

                Console.WriteLine(SieveOfEratosthenes(m).GetRange(n, m - n).Where(x => x == true).Count());

                // end of code
            }

        Console.ReadLine();
    }

    static List<bool> SieveOfEratosthenes(int max)
    {
        BitArray a = new BitArray(max, true);

        int lastPrime = 1;
        int lastPrimeSquare = 1;

        while (lastPrimeSquare <= max)
        {
            lastPrime++;

            while (!(bool)a[lastPrime])
                lastPrime++;

            lastPrimeSquare = lastPrime * lastPrime;

            for (int i = lastPrimeSquare; i < max; i += lastPrime)
                if (i > 0)
                    a[i] = false;
        }

        a[0] = false;
        a[1] = false;

        List<bool> ret = new List<bool>();
        foreach (bool b in a)
            ret.Add(b);

        return ret;
    }
}