using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxTravisGraham
{
    public class Parser
    {
        private IDictionary<String, int> table = new Dictionary<String, int>();
        private const int INDEX_OF_QUANTITY = 1;

        public bool ParseLine(String line)
        {
            // [] means optional
            //expects form of QUANTITY [IMPORTED] ITEM_NAME at BASE_PRICE
            String[] tokens = line.Split(' ');
            try
            {
                int quantity = GetQuantity(tokens[INDEX_OF_QUANTITY]);
                return true;

            }catch(Exception ex)
            {
                return false;
            }
            
        }

        private int GetQuantity(String token)
        {
            try
            {
                return 0;
            }catch(FormatException)
            {
                Console.WriteLine($"Unable to parse '{token}' as a Quantity. Now Aborting Program");
                throw new FormatException();
                return -1;
            }

        }
        
    }
}
