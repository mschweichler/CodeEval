using System;
using System.IO;

class DecodeNumbers
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

                Console.WriteLine(CountPossibleDecoding(line));

                //if (!reader.EndOfStream)
                //{
                //    Console.WriteLine();
                //}
                // end of code
            }

        Console.ReadLine();
    }

    static int CountPossibleDecoding(string message)
    {
        if (message.Length <= 1)
            return 1;

        int counter = 0;
        int length = 1;

        while(true)
        {
            if (length > message.Length)
                break;
            
            string substring = message.Substring(0, length);

            if (substring.Length != length)
                break;

            if (Convert.ToInt32(substring) > 26)
                break;

            counter += CountPossibleDecoding(message.Substring(length));
            length++;
        }

        return counter;
    }
}