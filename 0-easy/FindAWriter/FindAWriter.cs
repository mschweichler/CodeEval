using System;
using System.IO;
using System.Linq;

class FindAWriter
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

                string[] input = line.Split('|');
                string characters = input[0];
                int[] numbers = input[1].Trim().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

                foreach(int i in numbers)
                {
                    Console.Write(characters[i - 1]);
                }
                Console.WriteLine();

                // end of code
            }

        Console.ReadLine();
    }
}