using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class StringList
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
                int n = Convert.ToInt32(input[0]);
                List<char> chars = new List<char>(input[1].ToCharArray());

                Console.WriteLine(string.Join(",",getPermutations(chars, n).Select(x=> string.Join("",x)).Distinct().OrderBy(x=>x)));

                // end of code
            }

        Console.ReadLine();
    }

    static IEnumerable<IEnumerable<char>> getPermutations(IEnumerable<char> list, int length)
    {
        if (length == 1) return list.Select(t => new char[] { t });

        return getPermutations(list, length - 1).SelectMany(t => list,
                (t1, t2) => t1.Concat(new char[] { t2 }));
    }
}