using System;

class SumOfPrimes
{
    static void Main(string[] args)
    {
        int targetCount = 1000;
        int sum = 0;
        int[] primes = new int[targetCount];
        primes[0] = 2;
        primes[1] = 3;
        primes[2] = 5;
        primes[3] = 7;
        primes[4] = 11;
        primes[5] = 13;
        

        int counter = 6;
        for (int x = primes[counter - 1] + 2; counter < targetCount; x += 2)
        {
            if (IsPrime(x, primes))
            {
                primes[counter++] = x;
            }                
        }

        foreach (int pr in primes)
            sum += pr;

        Console.WriteLine(sum);
        Console.ReadLine();
    }
    
    static bool IsPrime(int p, int[] primes)
    {
        int max = (int)Math.Ceiling(Math.Sqrt(p));
        foreach (int divisor in primes)
        {
            if (divisor > max) break;
            if (p % divisor == 0) return false;
        }
        return true;
    }
}