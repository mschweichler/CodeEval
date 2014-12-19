using System;
using System.IO;

class ShortestRepetition
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

                string word = line;

                bool repetition = true;
                string lastKnownRepetition = "";
                string smallest = "";
                bool first = true;

                for(int i = 1; i <= word.Length; i++)
                {
                    string substring = word.Substring(0, i);
                    for(int x = 0; x<=word.Length-substring.Length; x+=substring.Length)
                    {
                        if (word.Substring(x, substring.Length) != substring)
                        {
                            repetition = false;
                            break;
                        }
                        if ((x == word.Length - substring.Length) && word.Substring(x, substring.Length) == substring)
                        {
                            repetition = true;
                        }
                    }
                    if (repetition)
                    {
                        if (first)
                        {
                            first = false;
                            smallest = substring;
                            lastKnownRepetition = substring;
                        }

                        lastKnownRepetition = substring;

                        if (lastKnownRepetition.Length < smallest.Length)
                            smallest = lastKnownRepetition;
                    }
                }

                Console.WriteLine(smallest.Length);

                // end of code
            }

        Console.ReadLine();
    }
}