using System;
using System.IO;

class DoubleSquares
{
    static void Main(string[] args)
    {
        bool firstLine = true;
        using (StreamReader reader = File.OpenText(args[0]))
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line || line == "" || firstLine)
                {
                    firstLine = false;
                    continue;
                }
                // code here

                Console.WriteLine(countDoubleSquares(Convert.ToInt32(line)));

                // end of code
            }

        Console.ReadLine();
    }

    public static int countDoubleSquares(int n)
    {
        int possibleDoubleSquares = 0;
        int x = (int)Math.Sqrt((double)n)+1;
        int y = 0;

        while(y<=x)
            if(Math.Pow(x,2) + Math.Pow(y,2) < n) y++;
            else if (Math.Pow(x, 2) + Math.Pow(y, 2) > n) x--;
            else if(Math.Pow(x,2)+Math.Pow(y,2) == n)
            {
                possibleDoubleSquares++;
                x--;
                y++;
            }            

        return possibleDoubleSquares;
    }
}