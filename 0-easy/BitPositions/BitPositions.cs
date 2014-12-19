using System;
using System.IO;

class BitPositions
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
                int n = Convert.ToInt32(input[0]);
                int p1 = Convert.ToInt32(input[1]);
                int p2 = Convert.ToInt32(input[2]);
                Console.WriteLine(compareBitPositions(n, p1, p2) ? "true" : "false");

                // end of code
            }

        Console.ReadLine();
    }

    public static bool compareBitPositions(int n, int p1, int p2)
    {
        bool b1 = (n & (0x1 << (p1 - 1))) == 0;
        bool b2 = (n & (0x1 << (p2 - 1))) == 0;

        return b1 == b2;
    }
}