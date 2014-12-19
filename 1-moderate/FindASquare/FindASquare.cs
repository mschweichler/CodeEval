using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class FindASquare
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

                Match input = Regex.Match(line, @"\((?<p1x>\d+),(?<p1y>\d+)\), \((?<p2x>\d+),(?<p2y>\d+)\), \((?<p3x>\d+),(?<p3y>\d+)\), \((?<p4x>\d+),(?<p4y>\d+)\)");

                Point p1 = new Point(double.Parse(input.Groups["p1x"].Value), double.Parse(input.Groups["p1y"].Value));
                Point p2 = new Point(double.Parse(input.Groups["p2x"].Value), double.Parse(input.Groups["p2y"].Value));
                Point p3 = new Point(double.Parse(input.Groups["p3x"].Value), double.Parse(input.Groups["p3y"].Value));
                Point p4 = new Point(double.Parse(input.Groups["p4x"].Value), double.Parse(input.Groups["p4y"].Value));

                Quadrilateral q = new Quadrilateral(p1, p2, p3, p4);                

                Console.WriteLine(q.IsSquare() ? "true" : "false");

                // end of code
            }

        Console.ReadLine();
    }

    struct Point
    {
        public double X;
        public double Y;

        public Point(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public double GetSquareDistanceTo(Point p)
        {
            return Math.Pow(this.X - p.X, 2) + Math.Pow(this.Y + p.Y, 2);
        }

        public static Point operator+(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point operator/(Point p1, double d)
        {
            return new Point(p1.X / d, p1.Y / d);
        }

        public static bool operator==(Point p1, Point p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator!=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Point)
            {
                Point p1 = (Point)obj;
                return this == p1;
            }
            else
                return false;
        }

        public bool Equals(Point p1)
        {
            return this == p1;
        }

        public override int GetHashCode()
        {
            return (int)((this.X + this.Y) % Int32.MaxValue);
        }
    }

    class Vector
    {
        public double X;
        public double Y;

        public Vector(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static Vector Rotate90(Vector v)
        {
            return new Vector(-v.Y, v.X);
        }

        public double GetDotProduct(Vector v)
        {
            return this.X * v.X + this.Y + v.Y;
        }
    }

    class Quadrilateral
    {
        private List<Point> points;

        public Quadrilateral(Point p1, Point p2, Point p3, Point p4)
        {
            points = new List<Point>() { p1, p2, p3, p4 };
        }

        public bool IsSquare()
        {
            if (points[0] == points[1] && points[1] == points[2] && points[2] == points[3])
                return false;

            Point center = (points[0] + points[1] + points[2] + points[3]) / 4;

            Vector v1 = new Vector(points[0].X - center.X, points[0].Y - center.Y);
            Vector v2 = Vector.Rotate90(v1);

            Point tmpP2 = new Point(center.X - v1.X, center.Y - v1.Y);
            Point tmpP3 = new Point(center.X + v2.X, center.Y + v2.Y);
            Point tmpP4 = new Point(center.X - v2.X, center.Y - v2.Y);

            return (points.Contains(tmpP2) && points.Contains(tmpP3) && points.Contains(tmpP4));
        }
    }
}