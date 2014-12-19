using System;
using System.IO;
using System.Text.RegularExpressions;

class PointInCircle
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

                Match input = Regex.Match(line, @"Center: \(([\d\.-]+), ([\d\.-]+)\); Radius: ([\d\.-]+); Point: \(([\d\.-]+), ([\d\.-]+)\)");

                // Circle
                Point center = new Point(Convert.ToDouble(input.Groups[1].Value), Convert.ToDouble(input.Groups[2].Value));
                double radius = Convert.ToDouble(input.Groups[3].Value);
                Circle circle = new Circle(center, radius);

                // Point
                Point point = new Point(Convert.ToDouble(input.Groups[4].Value), Convert.ToDouble(input.Groups[5].Value));


                Console.WriteLine(circle.isPointInside(point) ? "true" : "false");

                // end of code
            }

        Console.ReadLine();
    }

    struct Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    class Circle
    {
        private Point center;
        private double radius;

        public Circle(Point center, double radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public bool isPointInside(Point p)
        {
            return Math.Pow(p.X - this.center.X, 2) + Math.Pow(p.Y - this.center.Y, 2) < Math.Pow(this.radius, 2);
        }
    }
}