using System;
using System.IO;

class DeltaTime
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
                Console.WriteLine((TimeSpan.Parse(input[0]) - TimeSpan.Parse(input[1])).Duration());

                // end of code
            }

        Console.ReadLine();
    }
}