using System;
class Endianness
{
    static void Main()
    {
        Console.WriteLine(BitConverter.IsLittleEndian ? "LittleEndian" : "BigEndian");
        Console.ReadLine();
    }
}