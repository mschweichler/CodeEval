using System;
using System.IO;
using System.Linq;

class NmodM
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

                int[] input = line.Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                Console.WriteLine(NmodulusM(input[0], input[1]));

                // end of code
            }

        Console.ReadLine();
    }

    public static int NmodulusM(int N, int M)
    {
        return N - (M * (int)Math.Floor((double)(N / M)));
    }
}