using System;
using System.IO;

class Lowercase
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

                Console.WriteLine(line.ToLower());

                // end of code
            }

        Console.ReadLine();
    }
}