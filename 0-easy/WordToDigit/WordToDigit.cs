using System;
using System.IO;
using System.Collections.Generic;

class WordToDigit
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

                Dictionary<string, int> digits = new Dictionary<string,int>(){{"zero",0},{"one", 1},{"two",2},{"three",3},{"four",4},{"five",5},{"six",6},{"seven",7},{"eight",8},{"nine",9}};
                string[] input = line.Split(';');
                foreach(string s in input)
                {
                    Console.Write(digits[s]);
                }
                Console.WriteLine();

                // end of code
            }

        Console.ReadLine();
    }
}