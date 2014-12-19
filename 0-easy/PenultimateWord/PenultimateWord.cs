using System;
using System.IO;
using System.Linq;

class PenultimateWord
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
                Console.WriteLine(input[input.Length - 2]);

                // end of code
            }

        Console.ReadLine();
    }
}