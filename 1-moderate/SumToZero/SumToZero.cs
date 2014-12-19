using System;
using System.IO;
using System.Linq;

class SumToZero
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
                
                int[] numbers = line.Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                int[] range = new int[numbers.Length];
                for (int r = 0; r < numbers.Length; r++)
                    range[r] = r;

                int[][] keyCombinations = GetKCombinations(range, 4);

                int counter = 0;
                for (int i = 0; i < keyCombinations.Length; i++)
                {
                    int sum = 0;
                    for (int x = 0; x < keyCombinations[i].Length; x++)
                        sum += numbers[keyCombinations[i][x]];
                    if (sum == 0)
                        counter++;
                }

                Console.WriteLine(counter);

                // end of code
            }
        Console.ReadLine();
    }

    static int[][] GetKCombinations(int[] list, int length)
    {
        if (length == 1) return list.Select(t => new int[] { t }).ToArray();

        return GetKCombinations(list, length - 1)
            .SelectMany(t => list.Where(o => o > t.Last()),
                (t1, t2) => t1.Concat(new int[] { t2 }).ToArray()).ToArray();
    }
}