using System;
using System.IO;
using System.Linq;

class CapitalizeWords
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

                Console.WriteLine(string.Join(" ", line.Split(' ').Select(word => word[0].ToString().ToUpperInvariant() + word.Substring(1)).ToArray()));

                // end of code
            }

        Console.ReadLine();
    }
}