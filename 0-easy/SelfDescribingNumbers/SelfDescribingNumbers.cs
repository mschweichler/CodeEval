using System;
using System.IO;

class SelfDescribingNumbers
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
                char[] chars = line.ToCharArray();

                bool selfDescribingNumber = true;
                for (int i = 0; i < chars.Length; i++)
                {
                    int position = i;
                    int value = int.Parse(chars[i].ToString());
                    int counter = 0;

                    foreach (char c in chars)
                    {
                        if (c == char.Parse(position.ToString()))
                            counter++;
                    }

                    if (counter != value)
                    {
                        selfDescribingNumber = false;
                        break;
                    }
                }
                Console.Write(selfDescribingNumber ? 1 : 0);

                if (!reader.EndOfStream)
                {
                    Console.WriteLine();
                }
                // end of code
            }

        Console.ReadLine();
    }
}