using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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

                Console.WriteLine(
                    string.Join(",", 
                    getPermutations(line.ToList(), line.Length)
                    .Select(x => string.Join("", x.Select(c => c)))
                    .OrderBy(x => x, new StringComparer())));

                // end of code
            }

        Console.ReadLine();
    }

    public static IEnumerable<IEnumerable<char>> getPermutations(List<char> chars, int length)
    {
        if (length == 1)
            return chars.Select(t => new char[] { t });

        return getPermutations(chars, length - 1).SelectMany(t => chars.Where(e => !t.Contains(e)), (t1, t2) => t1.Concat(new char[] { t2 }));
    }

    public class StringComparer : IComparer<Object>
    {
        public int Compare(Object stringA, Object stringB)
        {
            string string1 = (string)stringA;
            string string2 = (string)stringB;

            for(int i=0;i<string1.Length;i++)
            {
                if (string1[i] == string2[i])
                    continue;
                return string1[i].CompareTo(string2[i]);
            }
            return string1.CompareTo(string2);
        }
    }
}