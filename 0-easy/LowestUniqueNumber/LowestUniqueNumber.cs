using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class LowestUniqueNumber
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
                
                List<int> players = line.Split(' ').Select(x => Convert.ToInt32(x)).ToList();
                List<int> numbers = new List<int>(players);
                numbers.Sort();

                int winner = 0;

                foreach (int n in numbers)
                {
                    if (numbers.Count(x => x == n) == 1)
                    {
                        winner = players.IndexOf(n) + 1;
                        break;
                    }
                }

                Console.WriteLine(winner);

                // end of code
            }

        Console.ReadLine();
    }
}