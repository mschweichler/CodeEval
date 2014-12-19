using System;
using System.IO;

class SumOfDigits
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

                Console.WriteLine(SumOfDigitsInNumber(line));

                // end of code
            }

        Console.ReadLine();
    }

    public static int SumOfDigitsInNumber(string numbers)
    {
        char[] chars = numbers.ToCharArray();
        int suma = 0;
        foreach (char c in chars)
        {
            suma += Convert.ToInt32(char.GetNumericValue(c));
        }
        return suma;
    }
}