using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class SumOfIntegers
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

                Console.WriteLine(FindMaximumSubsequence(line.Split(',').Select(x=>Convert.ToInt32(x))));
                // end of code
            }

        Console.ReadLine();
    }

    // Kadane's algorithm implementation
    public static int FindMaximumSubsequence(IEnumerable<int> source)
    {
        int result = int.MinValue;
        int sum = 0;
        int tempStart = 0;

        //int startIndex = 0;
        //int endIndex = 0;

        for (int index = 0; index < source.Count(); index++)
        {
            sum += source.ElementAt(index);
            if (sum > result)
            {
                result = sum;
                //startIndex = tempStart;
                //endIndex = index;
            }
            if (sum < 0)
            {
                sum = 0;
                tempStart = index + 1;
            }
        }

        return result;
    }
}