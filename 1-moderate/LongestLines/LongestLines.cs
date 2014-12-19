using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class LongestLines
{
    static void Main(string[] args)
    {
        int count = 0;
        List<string> lines = new List<string>();

        using (StreamReader reader = File.OpenText(args[0]))
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                    continue;
                // code here                
                if (count == 0)
                {
                    count = Convert.ToInt32(line);
                    continue;
                }
                lines.Add(line);
                // end of code
            }

        string[] sorted = lines.OrderByDescending(x => x.Length).ToArray();

        for (int x = 0; x < count; x++)
        {
            Console.WriteLine(sorted[x]);
        }

        Console.ReadLine();
    }
}