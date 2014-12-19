using System;
using System.IO;

class MinimumCoins
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

                int total = Convert.ToInt32(line);
                int counter = (int)(total / 5) + (int)((total % 5) / 3) + (int)((total % 5) % 3);

                Console.WriteLine(counter);

                // end of code
            }

        Console.ReadLine();
    }
}