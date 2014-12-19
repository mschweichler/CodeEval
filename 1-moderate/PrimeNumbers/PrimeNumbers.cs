using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

class PrimeNumbers
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

                uint n = Convert.ToUInt32(line);
                Console.WriteLine(string.Join(",", SieveOfEratosthenes(n-1)));

                // end of code
            }

        Console.ReadLine();
    }

    static List<uint> SieveOfEratosthenes(uint max)
    {
        //BitArray a = new BitArray(//new BitArray(max, true);
        bool[] tmp = new bool[uint.MaxValue-1];
        bool[] a = tmp.Select(x => !x).ToArray();
        

        uint lastPrime = 1;
        uint lastPrimeSquare = 1;

        while (lastPrimeSquare <= max)
        {
            lastPrime++;

            while (!(bool)a[lastPrime])
                lastPrime++;

            lastPrimeSquare = lastPrime * lastPrime;

            for (uint i = lastPrimeSquare; i < max; i += lastPrime)
                if (i > 0)
                    a[i] = false;
        }

        List<uint> ret = new List<uint>();
        for (uint i = 2; i < max; i++)
            if (a[i])
                ret.Add(i);

        return ret;
    }
}