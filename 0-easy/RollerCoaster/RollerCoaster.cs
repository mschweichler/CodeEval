using System;
using System.IO;

class RollerCoaster
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
                
                Console.WriteLine(toRollerCoasterCase(line));

                // end of code
            }

        Console.ReadLine();
    }

    public static string toRollerCoasterCase(string input)
    {
        string rollerString = "";
        bool toUpper = true;

        foreach (char c in input)
        {
            if (char.IsLetter(c))
                if (toUpper)
                {
                    rollerString += char.ToUpper(c);
                    toUpper = false;
                }
                else
                {
                    rollerString += char.ToLower(c);
                    toUpper = true;
                }
            else
                rollerString += c;
        }

        return rollerString;
    }
}