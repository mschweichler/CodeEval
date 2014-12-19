using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class WorkingExperience
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

                Console.WriteLine(getWorkingExperianceInFullYears(line));

                // end of code
            }

        Console.ReadLine();
    }

    //public static IEnumerable<DateTime> getMonths(DateTime start, DateTime end)
    //{
    //    IEnumerable<DateTime> months =
    //        Enumerable.Range(0, Int32.MaxValue)
    //        .Select(x => start.AddMonths(x))
    //        .TakeWhile(x => x <= new DateTime(end.Year, end.Month, DateTime.DaysInMonth(end.Year, end.Month)));
    //    //.Select(x => x);

    //    return months;
    //}

    public static int getWorkingExperianceInFullYears(string input)
    {
        IEnumerable<IEnumerable<DateTime>> dateRanges = input.Split(';').Select(range => range.Trim().Split('-').Select(date => DateTime.ParseExact(date, "MMM yyyy", System.Globalization.CultureInfo.InvariantCulture)));

        HashSet<DateTime> uniqueMonths = new HashSet<DateTime>();

        foreach (IEnumerable<DateTime> dR in dateRanges)
        {
            DateTime startDate = dR.First();
            DateTime endDate = dR.Last();
            IEnumerable<DateTime> monthsBetweenDates = Enumerable.Range(0, Int32.MaxValue)
                                                        .Select(x => startDate.AddMonths(x))
                                                        .TakeWhile(x => x <= new DateTime(endDate.Year, endDate.Month, 28));
            
            foreach (DateTime dT in monthsBetweenDates)
                uniqueMonths.Add(dT);
        }

        return uniqueMonths.Count / 12;
    }
}