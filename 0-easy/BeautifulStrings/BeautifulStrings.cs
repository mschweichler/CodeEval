using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class BeautifulStrings
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
                
                //Dictionary<char, int> histogram = Histogram(new string(line.ToUpperInvariant().Where(char.IsLetter).ToArray()));
                Dictionary<char, int> histogram = new string(line.ToUpperInvariant().Where(char.IsLetter).ToArray()).GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
                int sum = 0;
                int beauty = 26;
                foreach (var item in histogram.OrderByDescending(i => i.Value))
                {
                    sum += beauty * item.Value;
                    beauty--;
                }

                Console.WriteLine(sum);

                // end of code
            }

        Console.ReadLine();
    }

    //public static Dictionary<char, int> Histogram(string target)
    //{
    //    return target.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
    //}
}