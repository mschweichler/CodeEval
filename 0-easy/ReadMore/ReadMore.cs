using System;
using System.IO;

class ReadMore
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

                Console.WriteLine(getReadMore(line));

                // end of code
            }

        Console.ReadLine();
    }

    public static string getReadMore(string input)
    {
        if (input.Length <= 55)
            return input;
        else
        {
            string subString40 = input.Substring(0, 40);
            int lastSpaceIndex = subString40.LastIndexOf(' ');

            return lastSpaceIndex != -1 ? input.Substring(0, lastSpaceIndex) + "... <Read More>" : subString40 + "... <Read More>";
        }
    }
}