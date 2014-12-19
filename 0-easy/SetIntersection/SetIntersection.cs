using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class SetIntersection
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

                string[] input = line.Split(';');

                List<string> list1 = new List<string>(input[0].Split(','));
                List<string> list2 = new List<string>(input[1].Split(','));

                string[] intersection = list1.Intersect(list2).ToArray();

                Console.WriteLine(string.Join(",", intersection));

                // end of code
            }

        Console.ReadLine();
    }
}