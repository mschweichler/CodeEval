using System;
using System.IO;
using System.Net.Mail;
using System.Text.RegularExpressions;

class EmailValidation
{
    static void Main(string[] args)
    {
        using (StreamReader reader = File.OpenText(args[0]))
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line || "" == line)
                    continue;
                // code here

                bool isValidEmail = emailRegex.IsMatch(line);
                Console.WriteLine(isValidEmail ? "true" : "false");

                // end of code
            }

        Console.ReadLine();
    }

    public static Regex emailRegex = new Regex(
        "^[_A-Za-z0-9-\\.\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$|" +
        "^\"[_A-Za-z0-9-\\.\\+@]+(\\.[_A-Za-z0-9-]+)*\"@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$");
}