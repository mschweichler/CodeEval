using System;
using System.IO;
using System.Linq;

class OverlappingRectangles
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

                int[] input = line.Split(',').Select(x => Convert.ToInt32(x)).ToArray();

                Point R1upperLeft = new Point();
                Point R1lowerRight = new Point();

                Point R2upperLeft = new Point();
                Point R2lowerRight = new Point();

                R1upperLeft.X = input[0];
                R1upperLeft.Y = input[1];
                R1lowerRight.X = input[2];
                R1lowerRight.Y = input[3];

                R2upperLeft.X = input[4];
                R2upperLeft.Y = input[5];
                R2lowerRight.X = input[6];
                R2lowerRight.Y = input[7];

                bool isOverlapping = (
                    R1lowerRight.Y <= R2upperLeft.Y && 
                    R1upperLeft.Y >= R2lowerRight.Y && 
                    R1lowerRight.X >= R2upperLeft.X && 
                    R1upperLeft.X <= R2lowerRight.X );

                Console.WriteLine( isOverlapping ? "True" : "False");

                // end of code
            }

        Console.ReadLine();
    }

    struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }    
}