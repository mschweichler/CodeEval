using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class ValidParentheses
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

                //Console.WriteLine(isWellFormed(line) ? "True" : "False");
                Console.WriteLine(isWellFormed(line));

                // end of code
            }

        Console.ReadLine();
    }

    public static bool isWellFormed(string input)
    {
        Stack<char> parentheses = new Stack<char>();

        char[] open = { '(', '[', '{' };
        char[] close = { ')', ']', '}' };

        foreach (char c in input)
        {
            if (open.Contains(c))
                parentheses.Push(c);
            else
            {
                if (parentheses.Count == 0)
                    return false;
                if (c == close[0])
                {
                    if (parentheses.Peek() == open[0])
                        parentheses.Pop();
                }
                else if (c == close[1])
                {
                    if (parentheses.Peek() == open[1])
                        parentheses.Pop();
                }
                else if (c == close[2])
                {
                    if (parentheses.Peek() == open[2])
                        parentheses.Pop();
                }
            }
        }

        return parentheses.Count > 0 ? false : true;
    }
}