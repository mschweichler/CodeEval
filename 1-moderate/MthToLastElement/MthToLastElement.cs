using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class MthToLastElement
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
                int m = Convert.ToInt32(input[input.Length-1]);
                if (m > input.Length - 1)
                    continue;
                Console.WriteLine(input[input.Length-1-m]);

                // end of code
            }

        Console.ReadLine();
    }
}