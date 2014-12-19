using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class HiddenDigits
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

                Console.WriteLine(Decrypt(line));

                // end of code
            }

        Console.ReadLine();
    }

    public static Dictionary<char, char> hiddenDictionary =
        new Dictionary<char, char>() 
        { 
        { 'a', '0' }, { 'b', '1' }, { 'c', '2' }, { 'd', '3' }, 
        { 'e', '4' }, { 'f', '5' }, { 'g', '6' }, { 'h', '7' }, 
        { 'i', '8' }, { 'j', '9' } 
        };

    public static string Decrypt(string hidden)
    {
        string decrypted = string.Join("", hidden.Where(c => char.IsDigit(c) || (char.IsLower(c) && (int)c < 107)).Select(x => char.IsDigit(x) ? x : hiddenDictionary[x]));
        return decrypted.Length > 0 ? decrypted : "NONE";
    }
}