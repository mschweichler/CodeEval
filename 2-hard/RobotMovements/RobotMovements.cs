using System;

class RobotMovements
{
    static void Main(string[] args)
    {
        bool[,] map = {
                      {false,false,false,false},
                      {false,false,false,false},
                      {false,false,false,false},
                      {false,false,false,false}
                      };

        Console.WriteLine(count(map, 0, 0));
        Console.ReadLine();
    }

    static int count(bool[,] map, int curX, int curY, string path = "")
    {
        if (curX < 0 || curY < 0 || curX > 3 || curY > 3)
            return 0;

        if (map[curX, curY])
            return 0;

        if (curX == 3 && curY == 3)
        {
            path += string.Format("({0},{1})", curX, curY);
            //Console.WriteLine(path);
            return 1;
        }

        int result = 0;

        path += string.Format("({0},{1})", curX, curY);
        map[curX, curY] = true;
        result += count(map, curX + 1, curY, path);
        result += count(map, curX, curY + 1, path);
        result += count(map, curX - 1, curY, path);
        result += count(map, curX, curY - 1, path);
        map[curX, curY] = false;

        return result;
    }
}