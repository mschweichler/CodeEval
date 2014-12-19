using System;
using System.IO;
using System.Linq;

class ArmstrongNumbers
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

                Console.WriteLine(isArmstrongNumber(Convert.ToDouble(line)));

                // end of code
            }

        Console.ReadLine();
    }

    public static bool isArmstrongNumber(double number)
    {
        double[] digits = number.ToString().ToCharArray().Select(x => char.GetNumericValue(x)).ToArray();
        double sum = 0;
        foreach(double d in digits)
        {
            sum += Math.Pow(d,digits.Length);
        }
        return number == sum;
    }
}