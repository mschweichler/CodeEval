using System;
using System.Collections.Generic;
using System.IO;

class PascalsTriangle
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

                List<int> pascalsTriangleValues = new List<int>();

                for (int y = 0; y < Convert.ToInt32(line); y++)
                {
                    int c = 1;
                    for (int x = 0; x <= y; x++)
                    {
                        pascalsTriangleValues.Add(c);
                        c = c * (y - x) / (x + 1);
                    }
                }

                Console.WriteLine(string.Join(" ", pascalsTriangleValues));

                // end of code
            }

        Console.ReadLine();
    }
}