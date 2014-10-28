using System;
using System.IO;
using System.Collections.Generic;

class DataRecovery
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
                List<string> words = new List<string>(input[0].Split(' '));
                List<int> numbers = new List<int>();
                foreach (string s in input[1].Split(' '))
                {
                    numbers.Add(int.Parse(s));
                }
                SortedDictionary<int, string> dict = new SortedDictionary<int, string>();

                int unknown = 0;
                for (int x = 0; x < words.Count; x++)
                {
                    if (!numbers.Contains(x+1))
                        unknown = x+1;

                    if (x < words.Count-1)
                        dict.Add(numbers[x], words[x]);
                    else
                        dict.Add(unknown, words[words.Count - 1]);
                }

                string sentence = "";
                foreach(string word in dict.Values)
                {
                    sentence += word + " ";
                }
                Console.Write(sentence.Trim());


                if (!reader.EndOfStream)
                {
                    Console.WriteLine();
                }
                // end of code
            }

        Console.ReadLine();
    }
}