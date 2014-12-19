using System;
using System.IO;

class Program
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
                string S = input[0];
                string t = input[1];

                Console.WriteLine(S.LastIndexOf(t));

                // end of code
            }

        Console.ReadLine();
    }
}