using System;
using System.IO;
using System.Linq;

class SwapCase
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

                Console.WriteLine(line.Select(c => char.IsLower(c) ? char.ToUpper(c) : char.ToLower(c)).ToArray());

                // end of code
            }

        Console.ReadLine();
    }
}