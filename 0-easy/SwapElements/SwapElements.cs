using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class SwapElements
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

                string[] input = line.Split(':').Select(x => x.Trim()).ToArray();

                List<int> numbers = new List<int>(input[0].Split(' ').Select(i => Convert.ToInt32(i)));

                int[] positions = 
                    input[1].Split(',')
                    .Select(x => 
                        x.Split('-')
                        .Select(y => 
                            Convert.ToInt32(y.Trim())
                        )
                    ).SelectMany(z=>z).ToArray();

                for (int i = 0; i < positions.Count() - 1;i+=2 )
                    Swap(numbers, positions[i], positions[i + 1]);    
         
                Console.WriteLine(string.Join(" ", numbers));

                // end of code
            }

        Console.ReadLine();
    }

    public static void Swap(List<int> list, int index1, int index2)
    {
        int temp = list[index1];
        list[index1] = list[index2];
        list[index2] = temp;
    }
}