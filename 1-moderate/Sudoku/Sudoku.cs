using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Sudoku
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
                int size = Convert.ToInt32(input[0]);
                int[] numbers = input[1].Split(',').Select(x => Convert.ToInt32(x)).ToArray();

                int[,] sudoku = new int[size,size];

                for(int i=0;i<size*size;i++)
                {
                    int x = (int)i / size;
                    int y = i % size;

                    sudoku[x, y] = numbers[i];
                }

                int expectedSum = (size*(size+1))/2;
                bool validSudoku = true;

                if (validSudoku)
                {
                    for (int r = 0; r < size; r++)
                    {
                        if (sumRow(sudoku, r) != expectedSum || sumColumn(sudoku, r) != expectedSum)
                        {
                            validSudoku = false;
                            break;
                        }
                        if (!validSudoku)
                            break;
                    }
                }
                if(validSudoku)
                {
                    if(size == 4)
                    {
                        int sum1 = sudoku[0, 0] + sudoku[0, 1] + sudoku[1, 0] + sudoku[1, 1];
                        int sum2 = sudoku[0, 2] + sudoku[0, 3] + sudoku[1, 2] + sudoku[1, 3];
                        int sum3 = sudoku[2, 0] + sudoku[2, 1] + sudoku[3, 0] + sudoku[3, 1];
                        int sum4 = sudoku[2, 2] + sudoku[2, 3] + sudoku[3, 2] + sudoku[3, 3];

                        if (sum1 != expectedSum || sum2 != expectedSum || sum3 != expectedSum || sum4 != expectedSum)
                            validSudoku = false;
                    }
                    else if(size==9)
                    {
                        int sum1 = sudoku[0, 0] + sudoku[0, 1] + sudoku[0, 2] + sudoku[1, 0] + sudoku[1, 1] + sudoku[1, 2] + sudoku[2, 0] + sudoku[2, 1] + sudoku[2, 2];
                        int sum2 = sudoku[0, 3] + sudoku[0, 4] + sudoku[0, 5] + sudoku[1, 3] + sudoku[1, 4] + sudoku[1, 5] + sudoku[2, 3] + sudoku[2, 4] + sudoku[2, 5];
                        int sum3 = sudoku[0, 6] + sudoku[0, 7] + sudoku[0, 8] + sudoku[1, 6] + sudoku[1, 7] + sudoku[1, 8] + sudoku[2, 6] + sudoku[2, 7] + sudoku[2, 8];

                        int sum4 = sudoku[3, 0] + sudoku[3, 1] + sudoku[3, 2] + sudoku[4, 0] + sudoku[4, 1] + sudoku[4, 2] + sudoku[5, 0] + sudoku[5, 1] + sudoku[5, 2];
                        int sum5 = sudoku[3, 3] + sudoku[3, 4] + sudoku[3, 5] + sudoku[4, 3] + sudoku[4, 4] + sudoku[4, 5] + sudoku[5, 3] + sudoku[5, 4] + sudoku[5, 5];
                        int sum6 = sudoku[3, 6] + sudoku[3, 7] + sudoku[3, 8] + sudoku[4, 6] + sudoku[4, 7] + sudoku[4, 8] + sudoku[5, 6] + sudoku[5, 7] + sudoku[5, 8];

                        int sum7 = sudoku[6, 0] + sudoku[6, 1] + sudoku[6, 2] + sudoku[7, 0] + sudoku[7, 1] + sudoku[7, 2] + sudoku[8, 0] + sudoku[8, 1] + sudoku[8, 2];
                        int sum8 = sudoku[6, 3] + sudoku[6, 4] + sudoku[6, 5] + sudoku[7, 3] + sudoku[7, 4] + sudoku[7, 5] + sudoku[8, 3] + sudoku[8, 4] + sudoku[8, 5];
                        int sum9 = sudoku[6, 6] + sudoku[6, 7] + sudoku[6, 8] + sudoku[7, 6] + sudoku[7, 7] + sudoku[7, 8] + sudoku[8, 6] + sudoku[8, 7] + sudoku[8, 8];

                        if (sum1 != expectedSum || sum2 != expectedSum || sum3 != expectedSum || sum4 != expectedSum || sum5 != expectedSum || sum6 != expectedSum || sum7 != expectedSum || sum8 != expectedSum || sum9 != expectedSum)
                            validSudoku = false;
                    }
                }

                Console.WriteLine(validSudoku);
                // end of code
            }

        Console.ReadLine();
    }

    public static int sumRow(int[,] matrix, int row)
    {
        int sum = 0;
        for(int i=0;i<matrix.GetLength(0);i++)
        {
            sum += matrix[row, i];
        }
        return sum;
    }

    public static int sumColumn(int[,] matrix, int col)
    {
        int sum = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            sum += matrix[i, col];
        }
        return sum;
    }
}