using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class BigDigits
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

                IEnumerable<int> digits = line.Where(c => char.IsDigit(c)).Select(c => (int)char.GetNumericValue(c));

                for (int bigDigitLine = 0; bigDigitLine < 6; bigDigitLine++)
                {
                    foreach (int digit in digits)
                        Console.Write(bigDigits[digit][bigDigitLine]);
                    Console.WriteLine();
                }

                // end of code
            }

        Console.ReadLine();
    }

    public static readonly List<string[]> bigDigits = new List<string[]>
                {
                    // zero
                    new string[]{
                        "-**--", 
                        "*--*-", 
                        "*--*-", 
                        "*--*-", 
                        "-**--", 
                        "-----"},
                    // one
                    new string[]{
                        "--*--", 
                        "-**--", 
                        "--*--", 
                        "--*--", 
                        "-***-", 
                        "-----"},
                    // two
                    new string[]{
                        "***--", 
                        "---*-", 
                        "-**--", 
                        "*----", 
                        "****-", 
                        "-----"},
                    // three
                    new string[]{
                        "***--", 
                        "---*-", 
                        "-**--", 
                        "---*-", 
                        "***--", 
                        "-----"},
                    // four
                    new string[]{
                        "-*---", 
                        "*--*-", 
                        "****-", 
                        "---*-", 
                        "---*-", 
                        "-----"},
                    // five
                    new string[]{
                        "****-", 
                        "*----", 
                        "***--", 
                        "---*-", 
                        "***--", 
                        "-----"},
                    // six
                    new string[]{
                        "-**--", 
                        "*----", 
                        "***--", 
                        "*--*-", 
                        "-**--", 
                        "-----"},
                    // seven
                    new string[]{
                        "****-", 
                        "---*-", 
                        "--*--", 
                        "-*---", 
                        "-*---", 
                        "-----"},
                    // eight
                    new string[]{
                        "-**--", 
                        "*--*-", 
                        "-**--", 
                        "*--*-", 
                        "-**--", 
                        "-----"},
                    // nine
                    new string[]{
                        "-**--", 
                        "*--*-", 
                        "-***-", 
                        "---*-", 
                        "-**--", 
                        "-----"}
                };
}