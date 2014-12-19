using System;
using System.IO;
using System.Linq;

class LettercasePercentageRatio
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

                double lowercasePercentage = (line.Where(c => char.IsLower(c)).Count() / (double)line.Length) * 100;
                Console.WriteLine("lowercase: {0:f} uppercase: {1:f}", lowercasePercentage, 100 - lowercasePercentage);

                // end of code
            }

        Console.ReadLine();
    }
}