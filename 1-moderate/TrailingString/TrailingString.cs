using System;
using System.IO;

class TrailingString
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
                Console.WriteLine(input[0].EndsWith(input[1]) ? 1 : 0);

                // end of code
            }

        Console.ReadLine();
    }
}