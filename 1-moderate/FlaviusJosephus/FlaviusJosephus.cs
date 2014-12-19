using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class FlaviusJosephus
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

                string[] input = line.Split(',');
                int n = Convert.ToInt32(input[0]);
                int m = Convert.ToInt32(input[1]);

                LinkedList<int> numbers = new LinkedList<int>(Enumerable.Range(0, n));
                List<int> result = new List<int>();

                int iterator = 0;
                while (result.Count < n)
                {
                    iterator += m - 1;
                    while (iterator >= numbers.Count)
                        iterator -= numbers.Count;
                    if (numbers.Count == 1)
                    {
                        result.Add(numbers.First());
                        break;
                    }
                    result.Add(numbers.ElementAt(iterator));
                    numbers.Remove(result.Last());
                }

                Console.WriteLine(string.Join(" ", result));

                // end of code
            }

        Console.ReadLine();
    }
}