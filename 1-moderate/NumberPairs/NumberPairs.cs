using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class NumberPairs
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
                int[] numbers = input[0].Split(',').Select(x=>Convert.ToInt32(x)).ToArray();
                int sum = Convert.ToInt32(input[1]);

                List<string> pairs = findSumPairs(numbers, sum);

                Console.WriteLine(pairs.Count > 0 ? string.Join(";", pairs) : "NULL");

                // end of code
            }

        Console.ReadLine();
    }

    public static List<string> findSumPairs(int[] numbers, int sum)
    {
        int x = 0;
        int y = numbers.Length - 1;
        List<string> result = new List<string>();

        while(x<y)
        {
            if (numbers[x] + numbers[y] == sum)
            {
                result.Add(string.Format("{0},{1}", numbers[x], numbers[y]));
                x++;
                y--;
            }
            else if (numbers[x] + numbers[y] < sum)
                x++;
            else if (numbers[x] + numbers[y] > sum)
                y--;
        }

        return result;
    }
}