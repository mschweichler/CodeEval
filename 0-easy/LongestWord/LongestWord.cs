using System;
using System.IO;
using System.Linq;

class LongestWord
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

                Console.WriteLine(line.Split(' ').OrderByDescending(s => s.Length).First());

                // end of code
            }
        Console.ReadLine();
    }
}