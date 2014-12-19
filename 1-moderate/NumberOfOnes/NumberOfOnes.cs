using System;
using System.IO;

class NumberOfOnes
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

                Int32 number = Convert.ToInt32(line);
                int ones = 0;
                for (int i = 0; i < 32;i++ )
                    ones += (number & (1 << i)) != 0 ? 1 : 0;

                Console.WriteLine(ones);

                // end of code
            }

        Console.ReadLine();
    }
}