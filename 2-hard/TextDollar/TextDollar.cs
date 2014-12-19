using System;
using System.IO;

class TextDollar
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

                Console.WriteLine(NumberToText(int.Parse(line))+"Dollars");

                // end of code
            }

        Console.ReadLine();
    }

    public static string NumberToText(int number)
    {
        if (number == 0)
            return "Zero";

        string text = "";

        if ((number / 1000000) > 0)
        {
            text += NumberToText(number / 1000000) + "Million";
            number %= 1000000;
        }

        if ((number / 1000) > 0)
        {
            text += NumberToText(number / 1000) + "Thousand";
            number %= 1000;
        }

        if ((number / 100) > 0)
        {
            text += NumberToText(number / 100) + "Hundred";
            number %= 100;
        }

        if (number > 0)
        {
            var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            if (number < 20)
                text += unitsMap[number];
            else
            {
                text += tensMap[number / 10];
                if ((number % 10) > 0)
                    text += unitsMap[number % 10];
            }
        }

        return text;
    }
}