using System;
using System.IO;
using System.Linq;

class MultiplyLists
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

                int[][] values = 
                    line.Split('|')
                        .Select(x => x.Trim().Split(' ')
                            .Select(y => Convert.ToInt32(y.Trim()))
                        .ToArray())
                    .ToArray();

                Console.WriteLine(string.Join(" ",values[0].Zip(values[1], (a, b) => a * b)));

                // end of code
            }

        Console.ReadLine();
    }
}