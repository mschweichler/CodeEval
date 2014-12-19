using System;
using System.IO;

class Program
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

                Console.WriteLine(AngleDecimalToMinutesSeconds(line));

                // end of code
            }

        Console.ReadLine();
    }

    public static string AngleDecimalToMinutesSeconds(string input)
    {
        double d = Convert.ToDouble(input);
        double m = (d - Math.Floor(d)) * 60;
        double s = (m - Math.Floor(m)) * 60;
        return string.Format("{0}.{1:00}'{2:00}\"", (int)d, (int)m, (int)s);
    }
}