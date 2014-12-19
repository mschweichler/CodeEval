using System;
using System.IO;

class EvenNumbers
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

                Console.WriteLine(Convert.ToInt32(line[line.Length - 1]) % 2 == 0 ? 1 : 0);

                // end of code
            }

        Console.ReadLine();
    }
}