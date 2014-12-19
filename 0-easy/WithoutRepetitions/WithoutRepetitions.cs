using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class WithoutRepetitions
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

                Queue<char> chars = new Queue<char>(line);
                List<char> output = new List<char>();

                while(chars.Count>0)
                {
                    char tmp = chars.Dequeue();
                    if (output.LastOrDefault() != tmp)
                        output.Add(tmp);
                }

                Console.WriteLine(string.Join("", output));

                // end of code
            }

        Console.ReadLine();
    }
}