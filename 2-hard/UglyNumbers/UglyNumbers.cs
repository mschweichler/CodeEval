using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class UglyNumbers
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

                char[] nums = line.Where(c => char.IsDigit(c)).ToArray();
                char[] operators = new[] { '+', '-', ' '};
                int uglyCounter = 0;

                if (nums.Length == 1)
                    Console.WriteLine(isUgly((long)char.GetNumericValue(nums[0])) ? "1" : "0");
                else
                {
                    char[][] operatorPermutations = getOperatorPermutations(operators, nums.Length - 1);

                    for(int permutationGroup = 0; permutationGroup < operatorPermutations.Length ; permutationGroup++)
                    {
                        if(isUgly(EvaluateExpression(string.Join("", mergeDigitsWithOperators(nums, operatorPermutations[permutationGroup])))))
                            uglyCounter++;
                    }

                    Console.WriteLine(uglyCounter);
                }

                





                //if (nums.Length == 1)
                //{
                //    Console.WriteLine(isUgly((int)char.GetNumericValue(nums[0])) ? 1 : 0);
                //}
                //else
                //{
                //    //char[] operators = new[] { '+', '-', ' ' };
                //    char[][] test = getOperatorPermutations(operators, nums.Length - 1);

                //    //int uglyCounter = 0;

                //    for (int x = 0; x < test.Length; x++)
                //    {
                //        Queue<char> q = new Queue<char>(nums);
                //        StringBuilder expr = new StringBuilder();
                //        for (int i = 0; i < test[x].Length; i++)
                //        {
                //            expr.Append(q.Dequeue()).Append(test[x][i]);
                //        }
                //        if (q.Count > 0)
                //            expr.Append(q.Dequeue());

                //        if (isUgly(EvaluateExpression(expr.Replace(" ", "").ToString())))
                //            uglyCounter++;
                //    }

                //    Console.WriteLine(uglyCounter);
                //}

                //var result = new DataTable().Compute("1+23-4", null);

                //Console.WriteLine();

                // end of code
            }

        Console.ReadLine();
    }

    public static IEnumerable<char> mergeDigitsWithOperators(IEnumerable<char> digits, IEnumerable<char> operators)
    {
        using (IEnumerator<char> enumerator1 = digits.GetEnumerator(), enumerator2 = operators.GetEnumerator())
        {
            while (enumerator1.MoveNext())
            {
                yield return enumerator1.Current;
                if (enumerator2.MoveNext())
                    yield return enumerator2.Current;
            }
        }
    }

    public static long EvaluateExpression(string expression)
    {
        string[] operators = new[] { "+", "-" };
        Stack<long> values = new Stack<long>(expression.Split(new[] {'+','-'}).Select(x=>Convert.ToInt64(x.Replace(" ", string.Empty))));

        foreach(char c in expression)
        {
            if (c == '+')
                values.Push(values.Pop() + values.Pop());
            else if (c == '-')
                values.Push(values.Pop() - values.Pop());
        }

        return values.Peek();
    }

    public static bool isUgly(long number)
    {
        long n = Math.Abs(number);
        return n % 2 == 0 || n % 3 == 0 || n % 5 == 0 || n % 7 == 0;
    }

    public static char[][] getOperatorPermutations(char[] list, int length)
    {
        if (length == 1) return list.Select(t => new char[] { t }).ToArray();

        return getOperatorPermutations(list, length - 1)
            .SelectMany(t => list,
                (t1, t2) => t1.Concat(new char[] { t2 }).ToArray()).ToArray();
    }
}