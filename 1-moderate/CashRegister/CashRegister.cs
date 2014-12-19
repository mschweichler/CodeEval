using System;
using System.Collections.Generic;
using System.IO;

class CashRegister
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
                decimal PP = Convert.ToDecimal(input[0]);
                decimal CH = Convert.ToDecimal(input[1]);

                if (CH < PP)
                {
                    Console.WriteLine("ERROR");
                    continue;
                }
                if(CH == PP)
                {
                    Console.WriteLine("ZERO");
                    continue;
                }

                List<string> clientChange = getChange(CH - PP);
                Console.WriteLine(string.Join(",", clientChange));

                // end of code
            }

        Console.ReadLine();
    }

    public static List<string> getChange(decimal change)
    {
        var money = new[] 
                {
                    new { name = "ONE HUNDRED", value = 100m },
                    new { name = "FIFTY", value = 50m },
                    new { name = "TWENTY", value = 20m },
                    new { name = "TEN", value = 10m },
                    new { name = "FIVE", value = 5m },
                    new { name = "TWO", value = 2m },
                    new { name = "ONE", value = 1m },
                    new { name = "HALF DOLLAR", value = 0.5m },
                    new { name = "QUARTER", value = 0.25m },
                    new { name = "DIME", value = 0.1m },
                    new { name = "NICKEL", value = 0.05m },
                    new { name = "PENNY", value = 0.01m }                    
                };

        List<string> clientChange = new List<string>();

        while (change > 0)
        {
            foreach (var m in money)
            {
                if (m.value > change)
                    continue;
                if (m.value <= change)
                {
                    clientChange.Add(m.name);
                    change -= m.value;
                    break;
                }
            }
        }

        return clientChange;
    }
}