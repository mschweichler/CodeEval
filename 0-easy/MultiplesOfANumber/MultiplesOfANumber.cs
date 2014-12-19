using System;
using System.IO;

class MultiplesOfANumber
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
                Console.WriteLine(findSmallestMultipleOfNGreaterEqualX(Convert.ToInt32(input[0]), Convert.ToInt32(input[1])));

                // end of code
            }

        Console.ReadLine();
    }

    public static int findSmallestMultipleOfNGreaterEqualX(int x, int n)
    {
        int i = 1;
        while(x>n*i)i++;
        return n*i;
    }
}