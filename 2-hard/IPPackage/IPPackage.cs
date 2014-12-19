using System;
using System.IO;
using System.Linq;

class IPPackage
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

                string[] input = line.Split(' ');
                byte[] sourceIP = input[0].Split('.').Select(s => Convert.ToByte(s)).ToArray();
                byte[] destinationIP = input[1].Split('.').Select(s => Convert.ToByte(s)).ToArray();
                byte[] packet = input.Skip(2).Select(b => Convert.ToByte(b, 16)).ToArray();
                byte[] IPHeader = packet.Take(20).ToArray();

                sourceIP.CopyTo(IPHeader, 12);
                destinationIP.CopyTo(IPHeader, 16);

                UpdateChecksum(ref IPHeader);

                Console.WriteLine(string.Join(" ", IPHeader.Select(b => Convert.ToString(b, 16).PadLeft(2, '0'))));

                // end of code
            }

        Console.ReadLine();
    }

    public static void UpdateChecksum(ref byte[] header)
    {
        header[10] = 0;
        header[11] = 0;

        ushort word16;
        int sum = 0;

        for (int i = 0; i < 20; i += 2)
        {
            word16 = (ushort) (((header[i] << 8) & 0xFF00) + ((header[i + 1]) & 0xFF));
            sum += word16;
        }

        while ((sum >> 16) != 0)
        {
            sum = (sum & 0xFFFF) + (sum >> 16);
        }

        sum = ~sum;

        header[10] = (byte)(((ushort) sum >> 8));
        header[11] = (byte)(((ushort) sum & 0x00FF));
    }
}