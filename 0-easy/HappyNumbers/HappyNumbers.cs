using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class HappyNumbers
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

                Console.WriteLine(isHappyNumber(Convert.ToInt32(line), new HashSet<int>()) ? "1" : "0");

                // end of code
            }

        Console.ReadLine();
    }

    public static bool isHappyNumber(int number, HashSet<int> numberSequence)
    {
        int[] digits = number.ToString().ToCharArray().Select(x => (int)char.GetNumericValue(x)).ToArray();
        HashSet<int> nrSequence = numberSequence;
        bool isHappyNr = false;

        if(digits.Length != 1 || digits[0] != 1)
        {
            int newNumber = 0;
            foreach(int x in digits)
            {
                newNumber += x * x;
            }
            if (nrSequence.Add(newNumber))
                return isHappyNumber(newNumber, nrSequence);
            else
                return isHappyNr;
        }
        else
        {
            isHappyNr = true;
        }

        return isHappyNr;
    }
}