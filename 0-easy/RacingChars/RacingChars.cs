using System;
using System.Collections.Generic;
using System.IO;

class RacingChars
{
    static void Main(string[] args)
    {
        List<int> path = new List<int>();
        List<string> track = new List<string>();

        using (StreamReader reader = File.OpenText(args[0]))
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                    continue;

                track.Add(line);

                int checkpoint = line.IndexOf('C');
                int gate = line.IndexOf('_');

                if (checkpoint != -1)
                    path.Add(checkpoint);
                else
                    path.Add(gate);
            }

        for (int i = 0; i < path.Count; i++)
        {
            char[] tmp = track[i].ToCharArray();
            if (i == 0)
            {
                tmp[path[i]] = '|';
                Console.WriteLine(string.Join("", tmp));
            }
            else
            {
                if (path[i - 1] > path[i])
                    tmp[path[i]] = '/';
                else if (path[i - 1] < path[i])
                    tmp[path[i]] = '\\';
                else
                    tmp[path[i]] = '|';

                Console.WriteLine(string.Join("", tmp));
            }
        }

        Console.ReadLine();
    }
}