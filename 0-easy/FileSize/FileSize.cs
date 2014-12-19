using System;
using System.IO;

class FileSize
{
    static void Main(string[] args)
    {
        Console.WriteLine(new FileInfo(args[0]).Length);
        Console.ReadLine();
    }
}