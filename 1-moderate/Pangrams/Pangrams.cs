using System;
using System.IO;
using System.Linq;

class Pangrams
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

                string missingLetters = string.Join("", "abcdefghijklmnopqrstuvwxyz".Where(c => !line.ToLower().Contains(c)));
                Console.WriteLine(missingLetters == "" ? "NULL" : missingLetters);

                // end of code
            }

        Console.ReadLine();
    }
}