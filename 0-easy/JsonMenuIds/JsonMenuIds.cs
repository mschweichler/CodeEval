using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Regex regex = new Regex("\"id\": (\\d+), \"label\"", RegexOptions.Compiled);

        using (StreamReader reader = File.OpenText(args[0]))
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line || "" == line)
                    continue;
                // code here

                MatchCollection mc = regex.Matches(line);
                int sum = 0;
                foreach(Match m in mc)
                {
                    sum += Convert.ToInt32(m.Groups[1].Value);
                }
                Console.WriteLine(sum);

                // end of code
            }

        Console.ReadLine();
    }
}