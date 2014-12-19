using System;
using System.IO;
using System.Linq;

class FirstNonRepeatedCharacter
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

                Console.WriteLine(line.First(c => !line.Substring(line.IndexOf(c) + 1).Contains(c)));

                // end of code
            }

        Console.ReadLine();
    }
}