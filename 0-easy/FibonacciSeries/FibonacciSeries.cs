using System;
using System.IO;

class FibonacciSeries
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

                Console.WriteLine("{0:0}",Fibonacci(Convert.ToInt32(line)));

                // end of code
            }

        Console.ReadLine();
    }

    public static int Fibonacci(int n)
    {
        if (n == 0)
            return 0;
        if (n == 1 || n == 2)
            return 1;

        int[,] A = new int[2, 2] { { 0, 1 }, { 1, 1 } };
        int[,] B = (int[,])A.Clone();
        int[,] C = new int[2, 2];

        n -= 2;

        for (int i = 1; i <= n; i++)
        {
            C[0, 0] = B[0, 0] * A[0, 0] + B[0, 1] * A[1, 0];
            C[0, 1] = B[0, 0] * A[0, 1] + B[0, 1] * A[1, 1];
            C[1, 0] = B[1, 0] * A[0, 0] + B[1, 1] * A[1, 0];
            C[1, 1] = B[1, 0] * A[0, 1] + B[1, 1] * A[1, 1];

            B = (int[,])C.Clone();
        }
        return C[1, 1];
    }
}