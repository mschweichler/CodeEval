using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class ReverseGroups
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

                Queue<int> numbers = new Queue<int>(input[0].Split(',').Select(x => Convert.ToInt32(x)));
                int k = Convert.ToInt32(input[1]);

                List<int> sorted = new List<int>();

                while (numbers.Count > 0)
                {
                    if (k > numbers.Count)
                    {
                        sorted.Add(numbers.Dequeue());
                    }
                    else
                    {
                        List<int> tmp = new List<int>();
                        for (int i = 0; i < k; i++)
                        {
                            tmp.Add(numbers.Dequeue());
                        }
                        tmp.Reverse();
                        sorted.AddRange(tmp);
                    }
                }
                Console.WriteLine(string.Join(",", sorted));

                // end of code
            }

        Console.ReadLine();
    }
}