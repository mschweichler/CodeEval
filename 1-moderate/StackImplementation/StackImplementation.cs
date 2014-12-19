using System;
using System.IO;
using System.Collections.Generic;

class StackImplementation
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

                Stack<string> stack = new Stack<string>(line.Split(' '));
                int i = 0;
                while(stack.Count > 0)
                {
                    string value = stack.Pop();
                    if(i%2==0)
                        Console.Write("{0} ", value);
                    i++;
                }
                Console.WriteLine();

                // end of code
            }

        Console.ReadLine();
    }
}