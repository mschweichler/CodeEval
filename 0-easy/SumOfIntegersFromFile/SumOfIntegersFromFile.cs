using System;
using System.IO;

class SumOfIntegersFromFile
{
    static void Main(string[] args)
    {
        int sum = 0;

        using (StreamReader reader = File.OpenText(args[0]))
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                    continue;
                // code here

                sum += Convert.ToInt32(line);

                // end of code
            }
        Console.WriteLine(sum);
        Console.ReadLine();
    }
}