using System;
using System.IO;

class CompressedSequence
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

                string[] numbers = line.Split(' ');

                string current = numbers[0];
                int counter = 1;

                for (int i=1; i < numbers.Length;i++ )
                {
                    string num = numbers[i];
                    if (num != current)
                    {
                        Console.Write("{0} {1} ", counter, current);

                        current = num;
                        counter = 1;
                    }
                    else
                        counter++;
                }

                Console.WriteLine("{0} {1}", counter, current);

                // end of code
            }

        Console.ReadLine();
    }
}