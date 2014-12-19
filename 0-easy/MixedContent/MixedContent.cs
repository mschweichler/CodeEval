using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class MixedContent
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

                List<string> words = new List<string>();
                List<int> numbers = new List<int>();

                foreach(string s in input)
                {
                    int num;
                    if (int.TryParse(s.Trim(), out num))
                        numbers.Add(num);
                    else
                        if(s!="")
                            words.Add(s);
                }

                if (words.Count > 0)
                    Console.Write(string.Join(",", words));
                if (words.Count > 0 && numbers.Count > 0)
                    Console.Write("|");
                if (numbers.Count > 0)
                    Console.Write(string.Join(",", numbers));
                Console.WriteLine();                    

                // end of code
            }

        Console.ReadLine();
    }
}