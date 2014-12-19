using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class FilenamePattern
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

                string pattern = input[0].Replace(".", @"\.").Replace("*", ".*").Replace('?', '.');

                List<string> matches = new List<string>();

                for(int i = 1;i<input.Length;i++)
                    if (Regex.IsMatch(input[i], "^" + pattern + "$"))
                        matches.Add(input[i]);

                Console.WriteLine(matches.Count > 0 ? string.Join(" ", matches) : "-");

                // end of code
            }

        Console.ReadLine();
    }
}