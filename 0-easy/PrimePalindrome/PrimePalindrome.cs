using System;
using System.Collections;
using System.Collections.Generic;
class PrimePalindrome
{
    static void Main(string[] args)
    {
        int max = 1000;
        List<int> primes = SieveOfEratosthenes(max);
        primes.Reverse();

        foreach (int x in primes)
        {
            if (IsPalindrome(x))
            {
                Console.WriteLine(x);
                break;
            }                
        }
        
        Console.ReadLine();
    }

    static bool IsPalindrome(int number)
    {
        string s = number.ToString();
        int x = (int)(s.Length / 2);
        bool palindrom = true;

        int i = 0;
        while(palindrom && i<x)
        {
            if(s[i] == s[s.Length-1-i])
                palindrom = true;
            else
                palindrom = false;
            i++;
        }

        return palindrom;
    }

    static List<int> SieveOfEratosthenes(int max)
    {
        BitArray a = new BitArray(max, true);

        int lastPrime = 1;
        int lastPrimeSquare = 1;

        while(lastPrimeSquare<=max)
        {
            lastPrime++;

            while (!(bool)a[lastPrime])
                lastPrime++;

            lastPrimeSquare = lastPrime * lastPrime;

            for (int i = lastPrimeSquare; i < max; i += lastPrime)
                if (i > 0)
                    a[i] = false;
        }

        List<int> ret = new List<int>();
        for (int i = 2; i < max; i++)
            if (a[i])
                ret.Add(i);

        return ret;                
    }
}