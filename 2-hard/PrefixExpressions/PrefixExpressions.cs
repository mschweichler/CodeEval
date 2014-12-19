using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class PrefixExpressions
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

                Console.WriteLine(evaluatePrefixNotation(line));

                // end of code
            }

        Console.ReadLine();
    }

    public static int evaluatePrefixNotation(string expr)
    {
        // reverse polish notation
        string[] rpn = expr.Split(' ').Reverse().ToArray();

        // values stack
        Stack<decimal> values = new Stack<decimal>();

        string[] operators = { "+", "*", "/" };

        foreach(string s in rpn)
        {
            if (!operators.Contains(s))
                values.Push(Convert.ToDecimal(s));
            else
            {
                decimal tmp1 = values.Pop();
                decimal tmp2 = values.Pop();

                switch(s)
                {
                    case "+":
                        values.Push(tmp1 + tmp2);
                        break;
                    case "*":
                        values.Push(tmp1 * tmp2);
                        break;
                    case "/":
                        values.Push(tmp1 / tmp2);
                        break;
                }
            }
        }

        return (int)values.Peek();
    }
}