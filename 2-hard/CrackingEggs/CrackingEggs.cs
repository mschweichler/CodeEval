using System;
using System.IO;

class CrackingEggs
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

                string[] input = line.Split(' ');
                int numberOfEggs = int.Parse(input[0]);
                int numberOfFloors = int.Parse(input[1]);

                Console.WriteLine(GetMinimumDropsToDetermineTheFloor(numberOfEggs, numberOfFloors));

                // end of code
            }

        Console.ReadLine();
    }

    public static int GetMaximumFloors(int numberOfEggs, int numberOfDrops)
    {
        if (numberOfEggs == 0)
            return 0;
        else
        {
            int result = 0;
            for(int x=0;x<numberOfDrops;x++)
                result += GetMaximumFloors(numberOfEggs - 1, x) + 1;
            return result;
        }
    }

    public static int GetMinimumDropsToDetermineTheFloor(int numberOfEggs, int numberOfFloors)
    {
        int numberOfDrops = 0;
        while (GetMaximumFloors(numberOfEggs, numberOfDrops) < numberOfFloors)
            numberOfDrops++;
        return numberOfDrops;
    }
}