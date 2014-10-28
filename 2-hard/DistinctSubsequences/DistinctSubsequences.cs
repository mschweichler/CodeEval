using System;
using System.IO;

class DistinctSubsequences
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
                string haystack = input[0];
                string needle = input[1];

                Console.WriteLine(CountSubstrings(haystack, needle));

                // end of code
            }

        Console.ReadLine();
    }

    static int CountSubstrings(string haystack, string needle)
    {
        if (haystack.Length < needle.Length)
            return 0;

        if (haystack == needle)
            return 1;

        int counter = 0;
        if (haystack.Length > 0 && needle.Length > 0 && haystack[0] == needle[0])
            counter += CountSubstrings(haystack.Substring(1), needle.Substring(1));

        return (counter + CountSubstrings(haystack.Substring(1), needle));
    }
}