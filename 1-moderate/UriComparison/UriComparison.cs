using System;
using System.IO;
using System.Text.RegularExpressions;

class UriComparison
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

                string[] input = line.Split(';');
                Console.WriteLine(isUriEqual(normalize(input[0]),normalize(input[1])));
                

                // end of code
            }

        Console.ReadLine();
    }

    public static bool isUriEqual(string uri1, string uri2)
    {
        Match uri1Groups = Regex.Match(uri1, "^([a-zA-Z]+)://([a-zA-Z0-9.]+):?([0-9]+)?(.*)");
        Match uri2Groups = Regex.Match(uri2, "^([a-zA-Z]+)://([a-zA-Z0-9.]+):?([0-9]+)?(.*)");

        if (uri1Groups.Length == 0 || uri1Groups.Length == 0)
            return false;

        string uri1Scheme = uri1Groups.Groups[1].Value;
        string uri2Scheme = uri2Groups.Groups[1].Value;

        string uri1Host = uri1Groups.Groups[2].Value;
        string uri2Host = uri2Groups.Groups[2].Value;

        string uri1Port = uri1Groups.Groups[3].Value;
        uri1Port = uri1Port == "" ? "80" : uri1Port;
        string uri2Port = uri2Groups.Groups[3].Value;
        uri2Port = uri2Port == "" ? "80" : uri2Port;

        string uri1Path = uri1Groups.Groups[4].Value;
        string uri2Path = uri2Groups.Groups[4].Value;

        return (string.Compare(uri1Scheme, uri2Scheme, true) == 0 && string.Compare(uri1Host, uri2Host, true) ==0 && string.Compare(uri1Port, uri2Port, true)==0 && string.Compare(uri1Path, uri2Path)==0);
    }

    public static string normalize(string uri)
    {
        MatchCollection mC = Regex.Matches(uri, "%([0-9a-fA-F][0-9a-fA-F])");
        foreach(Match m in mC)
        {
            string oldChar = m.Groups[0].Value;
            string newChar = Convert.ToChar(Convert.ToInt32(m.Groups[1].Value, 16)).ToString();
            uri = uri.Replace(oldChar, newChar);
        }
        return uri;
    }
}