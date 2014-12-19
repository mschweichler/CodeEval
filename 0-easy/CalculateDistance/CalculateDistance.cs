using System;
using System.IO;
using System.Text.RegularExpressions;

class CalculateDistance
{
    static void Main(string[] args)
    {
        Regex reg = new Regex(@"([0-9-]+)[^-\d]*([0-9-]+)[^-\d]*([0-9-]+)[^-\d]*([0-9-]+)");

        using (StreamReader reader = File.OpenText(args[0]))
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                    continue;
                // code here

                Match m = reg.Match(line);
                Point p1 = new Point(Convert.ToInt32(m.Groups[1].Value), Convert.ToInt32(m.Groups[2].Value));
                Point p2 = new Point(Convert.ToInt32(m.Groups[3].Value), Convert.ToInt32(m.Groups[4].Value));

                Console.WriteLine(getDistanceBetweenPoints(p1, p2));

                // end of code
            }

        Console.ReadLine();
    }

    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public static double getDistanceBetweenPoints(Point p1, Point p2)
    {
        return Math.Sqrt(Math.Pow((p1.x - p2.x), 2) + Math.Pow((p1.y - p2.y), 2));
    }
}