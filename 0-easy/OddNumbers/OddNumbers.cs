using System;

class OddNumbers
{
    static void Main(string[] args)
    {
        // code here

        for (int i = 1; i < 100; i++)
            if (i % 2 != 0)
                Console.WriteLine(i);

        // end of code
        Console.ReadLine();
    }
}