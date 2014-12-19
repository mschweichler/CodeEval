using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class ArrayAbsurdity
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

                string[] input = line.Split(';');
                int N = Convert.ToInt32(input[0]);
                int[] numbers = input[1].Split(',').Select(x => Convert.ToInt32(x)).ToArray();

                int expectedSum = ((N - 1) * (N - 2) / 2);
                int actualSum = numbers.Sum();

                Console.WriteLine(actualSum - expectedSum);

                // end of code
            }

        Console.ReadLine();
    }
}