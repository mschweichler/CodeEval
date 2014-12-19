using System;
using System.IO;

class DecimalToBinary
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

                Console.WriteLine(DecToBin(Convert.ToInt32(line)));

                // end of code
            }
        Console.ReadLine();
    }

    public static string DecToBin(int number)
    {
        return Convert.ToString(number,2);
    }
}