using System;
using System.IO;
using System.Collections.Generic;

class SplitTheNumber
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

                string[] input = line.Split(' ');
                int plusIndex = input[1].IndexOf('+');
                int minusIndex = input[1].IndexOf('-');

                if (plusIndex > 0)
                {
                    int n1, n2;
                    n1 = Convert.ToInt32(input[0].Substring(0, plusIndex));
                    n2 = Convert.ToInt32(input[0].Substring(plusIndex));
                    Console.WriteLine(n1 + n2);
                }
                else if (minusIndex > 0)
                {
                    int n1, n2;
                    n1 = Convert.ToInt32(input[0].Substring(0, minusIndex));
                    n2 = Convert.ToInt32(input[0].Substring(minusIndex));
                    Console.WriteLine(n1 - n2);
                }

                // end of code
            }

        Console.ReadLine();
    }
}