using System;
using System.IO;
using System.Text;

class LongestCommonSubsequence
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
                string s1 = input[0];
                string s2 = input[1];

                LCS lcs = new LCS(s1, s2);
                //lcs.drawLCSMatrix();

                Console.WriteLine(lcs.LCSword.Trim());

                // end of code
            }

        Console.ReadLine();
    }

    class LCS
    {
        private int[,] LCSMatrix;
        private string string1;
        private string string2;
        private string lcsString;

        public LCS(string string1, string string2)
        {
            this.string1 = string1;
            this.string2 = string2;

            this.LCSMatrix = this.createLCSMatrix(this.string1, this.string2);
            this.lcsString = this.readLCSword(this.LCSMatrix, this.string1).ToString();
        }

        public string LCSword
        {
            get { return this.lcsString; }
            private set { this.lcsString = value; }
        }

        private int[,] createLCSMatrix(string s1, string s2)
        {
            int[,] matrix = new int[s1.Length + 1, s2.Length + 1];

            for (int x = 1; x < matrix.GetLength(0); x++)
            {
                for (int y = 1; y < matrix.GetLength(1); y++)
                {
                    if (s1[x - 1] == s2[y - 1])
                        matrix[x, y] = matrix[x - 1, y - 1] + 1;
                    else
                        if (matrix[x, y - 1] < matrix[x - 1, y])
                            matrix[x, y] = matrix[x - 1, y];
                        else
                            matrix[x, y] = matrix[x, y - 1];
                }
            }

            return matrix;
        }

        private StringBuilder readLCSword(int[,] matrix, string s1, int posX = -1, int posY = -1)
        {
            if (posX == -1 || posY == -1)
            {
                posX = matrix.GetLength(0) - 1;
                posY = matrix.GetLength(1) - 1;
            }

            if (matrix[posX, posY] == 0)
                return new StringBuilder();
            else if (matrix[posX, posY] == matrix[posX, posY - 1])
                return this.readLCSword(matrix, s1, posX, posY - 1);
            else if (matrix[posX, posY] == matrix[posX - 1, posY])
                return this.readLCSword(matrix, s1, posX - 1, posY);
            else
                return this.readLCSword(matrix, s1, posX - 1, posY - 1).Append(s1[posX - 1]);
        }

        public void drawLCSMatrix()
        {
            //Console.Clear();
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("string 1: {0}", this.string1);
            Console.WriteLine("string 2: {0}", this.string2);
            Console.WriteLine("LCS: {0}", this.lcsString);
            Console.WriteLine("Matrix:");
            for(int x = 0; x<this.LCSMatrix.GetLength(0);x++)
            {
                for(int y=0;y<this.LCSMatrix.GetLength(1);y++)
                {
                    if (x == 0 && y == 0)
                        Console.Write("   ");
                    if (y == 0 && x <= this.string1.Length && x > 0)
                        Console.Write("{0,3}", this.string1[x-1]);
                    if (x == 0 && y <= this.string2.Length && y > 0)
                        Console.Write("{0,3}", this.string2[y-1]);
                    if(x>0 && y>0)
                        Console.Write("{0,3}", this.LCSMatrix[x, y]);
                    if (y == this.LCSMatrix.GetLength(1)-1)
                        Console.WriteLine();
                }
                //Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------------------------------------------------");
        }
    }
}