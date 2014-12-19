using System;
using System.IO;

class JugglingWithZeros
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

                Console.WriteLine(zeroBasedToInteger(line));

                // end of code
            }

        Console.ReadLine();
    }

    public static long zeroBasedToInteger(string input)
    {
        string[] zeroBased = input.Split(' ');
        string binary = "";

        for (int i = 0; i < zeroBased.Length; i += 2)
        {
            string flag = zeroBased[i];
            string sequence = zeroBased[i + 1];

            if (flag == "0")
                binary += sequence;
            else if (flag == "00")
                binary += sequence.Replace('0', '1');
        }

        return Convert.ToInt64(binary, 2);
    }
}