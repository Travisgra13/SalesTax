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
            while (!line.ToLower().Equals("done") && successfulEntry)
            {
                line = Console.ReadLine();
                successfulEntry = parser.ParseLine(line);
                //check bool of Parser to ensure valid input

            }
            
        }
    }
}
