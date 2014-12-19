using System;
using System.IO;
using System.Collections.Generic;

class UniqueElements
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

                HashSet<string> list = new HashSet<string>(line.Split(','));
                HashSet<string>.Enumerator listEnumerator = list.GetEnumerator();

                for (int i = 0; i < list.Count-1;i++ )
                {
                    listEnumerator.MoveNext();
                    Console.Write("{0},", listEnumerator.Current);
                }
                listEnumerator.MoveNext();
                Console.WriteLine(listEnumerator.Current);

                // end of code
            }

        Console.ReadLine();
    }
}