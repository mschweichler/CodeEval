using System;
using System.IO;
using System.Text.RegularExpressions;

class SequenceTransformation
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
                string[] input = line.Split(' ');
                string binary = input[0];
                string letters = input[1];



                string pattern = "";
                foreach (char c in binary.ToCharArray())
                {
                    if (c == char.Parse("0"))
                        pattern += "(A+)";
                    else
                        pattern += "(A+|B+)";
                }

                Regex regex = new Regex(pattern, RegexOptions.Compiled);

                Console.Write(regex.IsMatch(letters) ? "Yes" : "No");

                if (!reader.EndOfStream)
                {
                    Console.WriteLine();
                }
                // end of code
            }

        Console.ReadLine();
    }
}