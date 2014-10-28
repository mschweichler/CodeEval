using System;
using System.IO;

class QueryBoard
{
    static void Main(string[] args)
    {
        Matrix board = new Matrix();

        using (StreamReader reader = File.OpenText(args[0]))
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                    continue;
                // code here
                string[] input = line.Split(' ');
                string command = input[0];

                switch(command)
                {
                    case "SetRow":
                        {
                            int i = int.Parse(input[1]);
                            int x = int.Parse(input[2]);
                            board.SetRow(i, x);
                            break;
                        }                        
                    case "SetCol":
                        {
                            int j = int.Parse(input[1]);
                            int x = int.Parse(input[2]);
                            board.SetCol(j, x);
                            break;
                        }
                    case "QueryRow":
                        {
                            int i = int.Parse(input[1]);
                            Console.WriteLine(board.QueryRow(i));
                            break;
                        }
                    case "QueryCol":
                        {
                            int j = int.Parse(input[1]);
                            Console.WriteLine(board.QueryCol(j));
                            break;
                        }
                }
            }

        Console.ReadLine();
    }

    public class Matrix
    {
        private int size;
        private int[,] matrix;

        public Matrix(int size = 256)
        {
            this.size = size;
            this.matrix = new int[this.size, this.size];
        }

        // i -> row
        // x -> value
        public void SetRow(int i, int x)
        {
            for (int col = 0; col < size; col++)
            {
                this.matrix[i, col] = x;
            }
        }

        // j -> column
        // x -> value
        public void SetCol(int j, int x)
        {
            for (int row = 0; row < size; row++)
            {
                this.matrix[row, j] = x;
            }
        }

        // i -> row
        public int QueryRow(int i)
        {
            int sum = 0;
            for (int col = 0; col < size; col++)
            {
                sum += this.matrix[i, col];
            }

            return sum;
        }

        // j -> column
        public int QueryCol(int j)
        {
            int sum = 0;
            for (int row = 0; row < size; row++)
            {
                sum += this.matrix[row, j];
            }

            return sum;
        }
    }
}