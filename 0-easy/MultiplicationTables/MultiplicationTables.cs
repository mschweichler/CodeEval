using System;

class MultiplicationTables
{
    static void Main(string[] args)
    {
        for (int x = 1; x <= 12; x++)
        {
            for (int y = 1; y <= 12; y++)
            {
                Console.Write("{0,4}", x * y);
            }
            Console.WriteLine();
        }
        Console.ReadLine();
    }
}