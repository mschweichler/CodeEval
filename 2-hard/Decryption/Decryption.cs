using System;
using System.Collections.Generic;

class Decryption
{
    static void Main()
    {
        string message = "012222 1114142503 0313012513 03141418192102 0113 2419182119021713 06131715070119";
        string keyed_alphabet = "BHISOECRTMGWYVALUZDNFJKPQX";

        Dictionary<char, int> dict = new Dictionary<char, int>();
        for (int x = 0; x < keyed_alphabet.Length; x++)
        {
            dict.Add(keyed_alphabet[x], x);
        }
        int i = 0;
        while (i < message.Length)
        {
            if (message[i] == ' ')
            {
                Console.Write(" ");
                i++;
                continue;
            }
            int charValue = ((message[i++] - '0') * 10) + (message[i++] - '0');
            Console.Write((char)('A' + dict[(char)('A' + charValue)]));
        }
        Console.ReadLine();
    }
}