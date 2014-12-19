using System;
using System.IO;

class AgeDistribution
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

                Console.WriteLine(getDemographicMsg(line));

                // end of code
            }
        Console.ReadLine();
    }

    public static string getDemographicMsg(string input)
    {
        int age = Convert.ToInt32(input);

        if (age < 0 || age > 100)
            return "This program is for humans";
        if (age <= 2)
            return "Still in Mama's arms";
        if (age <= 4)
            return "Preschool Maniac";
        if (age <= 11)
            return "Elementary school";
        if (age <= 14)
            return "Middle school";
        if (age <= 18)
            return "High school";
        if (age <= 22)
            return "College";
        if (age <= 65)
            return "Working for the man";
        else
            return "The Golden Years";
    }
}