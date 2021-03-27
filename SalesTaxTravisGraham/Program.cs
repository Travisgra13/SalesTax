using System;

namespace SalesTaxTravisGraham
{
    class Program
    {
        static void Main(string[] args)
        {
            String line = "";
            Console.WriteLine("Instructions go here");
            Parser parser = new Parser();
            bool successfulEntry = true;
            line = Console.ReadLine();
            while (!line.ToLower().Equals("done") && successfulEntry)
            {
                successfulEntry = parser.ParseLine(line);
                line = Console.ReadLine();
            }

            Outputter output = parser.GetOutputter();
            Console.Write(output.ToString());
            
        }
    }
}
