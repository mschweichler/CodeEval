using System;
using System.IO;
using System.Linq;

class JollyJumpers
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

                int[] input = line.Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                bool jollyJumper = true;
                if (input.Length > 1)
                    for (int i = 1; i < input.Length - 1; i++)
                        if (Math.Abs(input[i] - input[i + 1]) != i)
                        {
                            jollyJumper = false;
                            break;
                        }                        

                Console.WriteLine(jollyJumper ? "Jolly" : "Not jolly");

                // end of code
            }

        Console.ReadLine();
    }
}