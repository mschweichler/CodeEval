using System;
using System.IO;
using System.Text;

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

                string[] input = line.Split(',');

                string word1 = input[0];
                string word2 = input[1];

                foreach (char c in word1)
                    if (word1 != word2)
                        Rotate(ref word2);

                Console.WriteLine(word1 == word2);

                // end of code
            }

        Console.ReadLine();
    }

    public static void Rotate(ref string word)
    {
        StringBuilder sB = new StringBuilder(word);
        word = sB.Append(sB[0]).Remove(0, 1).ToString();
    }
}