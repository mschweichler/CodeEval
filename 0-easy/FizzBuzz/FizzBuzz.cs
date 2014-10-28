using System;
using System.IO;

class FizzBuzz
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
                string[] input = line.Split(' ');
                byte x = byte.Parse(input[0]);
                byte y = byte.Parse(input[1]);
                byte n = byte.Parse(input[2]);

                for (byte q = 1; q <= n; q++)
                {
                    bool fizz = (q % x == 0);
                    bool buzz = (q % y == 0);
                    bool fizzbuzz = (fizz && buzz);

                    if (fizzbuzz)
                    { 
                        Console.Write("FB");
                        if (q != n)
                            Console.Write(" ");
                        continue;
                    }
                    if(fizz)
                    {
                        Console.Write("F");
                        if (q != n)
                            Console.Write(" ");
                        continue;
                    }
                    if(buzz)
                    {
                        Console.Write("B");
                        if (q != n)
                            Console.Write(" ");
                        continue;
                    }
                    Console.Write(q);
                    if (q != n)
                        Console.Write(" ");
                }
                if(!reader.EndOfStream)
                {
                    Console.WriteLine();
                }
                // end of code
            }

        Console.ReadLine();
    }
}