using System;
using System.IO;
using System.Linq;

class ReverseAndAdd
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

                int n = Convert.ToInt32(line);
                int iterations = findPalindrome(ref n);
                Console.WriteLine("{0} {1}", iterations, n);

                // end of code
            }

        Console.ReadLine();
    }
    
    public static int findPalindrome(ref int n)
    {
        int counter = 0;
        while(!isPalindrome(n) && counter <= 100)
        {
            counter++;
            n += getReverse(n);
        }

        return counter;
    }

    public static int getReverse(int n)
    {
        int reverse = 0;
        while(n>0)
        {
            reverse = reverse * 10 + n % 10;
            n /= 10;
        }
        return reverse;
    }


    public static bool isPalindrome(int n)
    {
        return n == getReverse(n);
    }
}