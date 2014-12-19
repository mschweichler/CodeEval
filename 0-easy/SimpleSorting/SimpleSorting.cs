using System;
using System.IO;
using System.Linq;


class SimpleSorting
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

                Console.WriteLine(string.Join(" ", line.Split(' ').Select(x => Convert.ToDouble(x)).OrderBy(x => x).Select(s => string.Format("{0:N3}", s)).ToArray<string>()));
                //string[] numbers = line.Split(' ').Select(x => Convert.ToDouble(x)).OrderBy(x => x).Select(s => Convert.ToString(s)).ToArray();
                //Console.WriteLine(string.Join(" ", numbers));

                // end of code
            }

        Console.ReadLine();
    }
}