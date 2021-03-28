using System;

namespace SalesTaxTravisGraham
{
    class Program
    {
        private const String HELP = "Enter items of receipts in the form: QUANTITY[\"IMPORTED\"] ITEM_NAME at BASE_PRICE followed by 'done' when it is complete.";
        private const String EXTRA_HELP = "Enter items of receipts in the form: QUANTITY[\"IMPORTED\"] ITEM_NAME at BASE_PRICE. Imported is an optional argument. Remember to enter 'done' when finished adding items.";
        private const String VALID_MESSAGE = "Successfully Added item";
        static void Main(string[] args)
        {
            String line = "";

            Console.WriteLine(HELP);
            Parser parser = new Parser();
            bool successfulEntry = true;
            line = Console.ReadLine();
            while (!line.ToLower().Equals("done"))
            {
                successfulEntry = parser.ParseLine(line);
                if (!successfulEntry)
                {
                    Console.WriteLine(EXTRA_HELP);
                }
                else
                {
                    Console.WriteLine(VALID_MESSAGE);
                }
                line = Console.ReadLine();
            }

            Outputter output = parser.GetOutputter();
            Console.Write(output.ToString());
            
        }
    }
}
