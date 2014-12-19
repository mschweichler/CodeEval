using System;
using System.IO;
//using System.Linq;
using System.Collections.Generic;


class RoadTrip
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

                Console.WriteLine(getResult2(line));

                // end of code
            }

        Console.ReadLine();
    }

    //public static string getResult(string input)
    //{
    //    List<int> dist =
    //                input.TrimEnd(';').Split(';')
    //                .Select(city =>
    //                    Convert.ToInt32(city.Split(',').ElementAt(1)))
    //                    .OrderBy(x => x).ToList();

    //    List<int> wynik = new List<int>();
    //    wynik.Add(dist[0]);
    //    for (int i = 0; i < dist.Count - 1; i++)
    //        wynik.Add(dist[i + 1] - dist[i]);

    //    return string.Join(",", wynik);
    //}

    // faster
    public static string getResult2(string input)
    {
        List<char> digits = new List<char>();
        List<int> distances = new List<int>();

        foreach(char c in input)
        {            
            if(c==',') digits.Clear();
            if (char.IsDigit(c)) digits.Add(c);
            if(c==';') distances.Add(Convert.ToInt32(string.Join("", digits)));                    
        }

        distances.Sort();

        List<int> wynik = new List<int>();
        wynik.Add(distances[0]);
        for (int i = 0; i < distances.Count - 1; i++)
            wynik.Add(distances[i + 1] - distances[i]);

        return string.Join(",", wynik);
    }
}