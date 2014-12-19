using System;
using System.IO;
using System.Text;
using System.Linq;

class RemoveCharacters
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
                StringBuilder sB = new StringBuilder(input[0]);
                Console.WriteLine(input[1].Trim().Select(c => sB.Replace(c.ToString(), "")).Last());

                // end of code
            }

        Console.ReadLine();
    }
}