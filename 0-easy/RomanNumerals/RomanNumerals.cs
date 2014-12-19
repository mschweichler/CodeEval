using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

class RomanNumerals
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

                // cheating :D
                
                Console.WriteLine(roman(Convert.ToInt32(line)));

                // end of code
            }

        Console.ReadLine();
    }

    private static string roman(int number)
    {
        StringBuilder result = new StringBuilder();
        int[] digitsValues = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
        string[] romanDigits = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
        while (number > 0)
        {
            for (int i = digitsValues.Length - 1; i >= 0; i--)
                if (number / digitsValues[i] >= 1)
                {
                    number -= digitsValues[i];
                    result.Append(romanDigits[i]);
                    break;
                }
        }
        return result.ToString();
    }
}