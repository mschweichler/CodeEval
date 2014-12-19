using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class APileOfBricks
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

                // [-1,-5] [5,-2]|(1 [4,7,8] [2,9,0]);(2 [0,7,1] [5,9,8])
                string[] input = line.Split('|');
                string[] bricksInput = input[1].Split(';');
                
                var holeRegex = Regex.Match(input[0], @"\[(?<holeX1>[-0-9]+),(?<holeY1>[-0-9]+)\] \[(?<holeX2>[-0-9]+),(?<holeY2>[-0-9]+)\]");

                List<Brick> bricks = new List<Brick>();

                foreach(string brick in bricksInput)
                {
                    var brickRegex = Regex.Match(brick, @"\((?<brickIndex>\d+) \[(?<brickX1>[-0-9]+),(?<brickY1>[-0-9]+),(?<brickZ1>[-0-9]+)\] \[(?<brickX2>[-0-9]+),(?<brickY2>[-0-9]+),(?<brickZ2>[-0-9]+)\]\)");

                    bricks.Add(new Brick(int.Parse(brickRegex.Groups["brickIndex"].Value), int.Parse(brickRegex.Groups["brickX1"].Value), int.Parse(brickRegex.Groups["brickY1"].Value), int.Parse(brickRegex.Groups["brickZ1"].Value), int.Parse(brickRegex.Groups["brickX2"].Value), int.Parse(brickRegex.Groups["brickY2"].Value), int.Parse(brickRegex.Groups["brickZ2"].Value)));
                }

                Rectangle hole = new Rectangle(int.Parse(holeRegex.Groups["holeX1"].Value), int.Parse(holeRegex.Groups["holeY1"].Value), int.Parse(holeRegex.Groups["holeX2"].Value), int.Parse(holeRegex.Groups["holeY2"].Value));

                List<int> canPass = new List<int>();

                foreach(Brick b in bricks)
                {
                    if (hole.CompareTo(b) == 1)
                        canPass.Add(b.index);
                }

                if (canPass.Count > 0)
                    Console.WriteLine(string.Join(",", canPass));
                else
                    Console.WriteLine("-");

                // end of code
            }

        Console.ReadLine();
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point(int X, int Y, int Z = 0)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
    }

    public class Rectangle : IComparable<Rectangle>
    {
        public Point LeftTop { get; set; }
        public Point LeftBottom { get; set; }
        public Point RightTop { get; set; }
        public Point RightBottom { get; set; }

        public List<int> squareLengths { get; set; }

        public double length { get; set; }
        public double width { get; set; }

        public Rectangle(int x1, int y1, int x2, int y2)
            : this(new Point(x1, y1), new Point(x2, y2))
        { }
        public Rectangle(Point p1, Point p2)
        {
            squareLengths = new List<int>();

            LeftTop = new Point(p1.X, p2.Y);
            RightBottom = new Point(p2.X, p2.Y);
            LeftBottom = new Point(p1.X, p2.Y);
            RightTop = new Point(p2.X, p1.Y);

            squareLengths.Add((int)(Math.Pow(LeftTop.X - RightTop.X, 2) + Math.Pow(LeftTop.Y - RightTop.Y, 2)));
            squareLengths.Add((int)(Math.Pow(LeftTop.X - LeftBottom.X, 2) + Math.Pow(LeftTop.Y - LeftBottom.Y, 2)));

            length = Math.Sqrt(squareLengths.Max());
            width = Math.Sqrt(squareLengths.Min());
        }


        public int CompareTo(Rectangle other)
        {
            if (this.length > other.length || this.width > other.width)
                return 1;
            else if (this.length < other.length || this.width < other.width)
                return -1;
            else
                return 0;
        }
    }

    public class Brick : Rectangle
    {
        public int index { get; set; }

        public Brick(int index, int x1, int y1, int z1, int x2, int y2, int z2)
            : base(x1, y1, x2, y2)
        {
            this.index = index;
        }
    }
}