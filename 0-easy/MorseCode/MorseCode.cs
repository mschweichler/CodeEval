using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

class MorseCode

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

                Console.WriteLine(translateMorse(line));

                // end of code
            }

        Console.ReadLine();
    }

    public static string translateMorse(string morse)
    {        
        Dictionary<string, char> morseCode = new Dictionary<string,char>()
        {
            {".-" , 'A'}, {"-..." , 'B'}, {"-.-." , 'C'}, {"-.." , 'D'}, {"." , 'E'}, {"..-." , 'F'}, {"--." , 'G'},
            {"...." , 'H'}, {".." , 'I'}, {".---" , 'J'}, {"-.-" , 'K'}, {".-.." , 'L'}, {"--" , 'M'}, {"-." , 'N'},
            {"---" , 'O'}, {".--." , 'P'}, {"--.-" , 'Q'}, {".-." , 'R'}, {"..." , 'S'}, {"-" , 'T'}, {"..-" , 'U'},
            {"...-" , 'V'}, {".--" , 'W'}, {"-..-" , 'X'}, {"-.--" , 'Y'}, {"--.." , 'Z'}, {"-----" , '0'}, {".----" , '1'},
            {"..---" , '2'}, {"...--" , '3'}, {"....-" , '4'}, {"....." , '5'}, {"-...." , '6'}, {"--..." , '7'},
            {"---.." , '8'}, {"----." , '9'}
        };

        return string.Join(" ", morse.Replace("  ", ",").Split(',').Select(word => string.Join("", word.Split(' ').Select(chars => morseCode[chars]))));               
    }
}