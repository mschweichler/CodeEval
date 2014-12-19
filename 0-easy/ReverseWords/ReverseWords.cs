using System;
using System.IO;
using System.Collections.Generic;

class ReverseWords
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

                Stack<string> words = new Stack<string>(line.Split(' '));
                while (words.Count > 1)
                    Console.Write("{0} ", words.Pop());
                Console.WriteLine(words.Pop());

                // end of code
            }

        Console.ReadLine();
    }
}