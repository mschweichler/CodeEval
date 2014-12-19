using System;
using System.IO;
using System.Collections.Generic;
using System.Numerics;

class ClimbingStairs
{
    static void Main(string[] args)
    {
        using (StreamReader reader = File.OpenText(args[0]))
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line || "" == line)
                    continue;
                // code here

                Console.WriteLine(countSteps(Convert.ToInt32(line)));

                // end of code
            }

        Console.ReadLine();
    }
     
    public static Dictionary<int, BigInteger> ways = new Dictionary<int, BigInteger>() { { 1, 1 }, { 2, 2 } };
    public static BigInteger countSteps(int stairs)
    {
        BigInteger possibleWays;
        if (ways.TryGetValue(stairs, out possibleWays))
        {
            return possibleWays;
        }

        BigInteger result = countSteps(stairs - 1) + countSteps(stairs - 2);
        ways[stairs] = result;
        return result;
    }
}