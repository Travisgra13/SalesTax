using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxTravisGraham
{
    public class Parser
    {
        //private IDictionary<String, List<Item.Item>> itemTable = new Dictionary<String, List<Item.Item>>();
        private Outputter output = new Outputter();
        private ItemDeterminer itemDeterminer = new ItemDeterminer();
        private const int INDEX_OF_QUANTITY = 0;
        private const int INDEX_OF_OPTIONAL_IMPORTED = 1;

        public bool ParseLine(String line)
        {
            // [] means optional
            //expects form of QUANTITY [IMPORTED] ITEM_NAME at BASE_PRICE
            String[] tokens = line.Split(' ');
            try
            {
                int quantity = GetQuantity(tokens[INDEX_OF_QUANTITY]);
                if (!HasAtToken(line))
                {
                    //we don't have an at token
                    Console.WriteLine("There is no 'at' in this string. Try again");
                    return false;
                }
                bool hasImport = HasImportedToken(tokens[INDEX_OF_OPTIONAL_IMPORTED]);
                String itemName = "";
                int offsetIndex = INDEX_OF_OPTIONAL_IMPORTED;
                if (hasImport) { offsetIndex++; } //add to offset
                int indexOfAt = 0;
                //if this has an import, the concatenation of (INDEX_OF_OPTIONAL_IMPORTED + 1 -> (index of "at" token - 1) in tokens is the item_name 
                Tuple<String, int> result = DetermineItemName(tokens, offsetIndex, hasImport);
                itemName = result.Item1;
                indexOfAt = result.Item2;
                double basePrice = GetBasePrice(tokens[indexOfAt + 1]);
                AddToTable(quantity, itemName, basePrice, hasImport);
                return true;

            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Unable to parse '{line}' Try again.");
                return false;
            }
            catch(Exception)
            {
                return false;
            }
            
        }

        private void AddToTable(int quantity, String itemName, double basePrice, bool imported)
        {
            Item.Item item = itemDeterminer.Itemize(itemName, basePrice, quantity, imported);
            if (output.ContainsKey(itemName))
            {
                List<Item.Item> items = output[itemName];
                items.Add(item);
                output[itemName] = items;
            }
            else
            {
                List<Item.Item> items = new List<Item.Item>();
                items.Add(item);
                output.Add(itemName, items);
            }

        }

        private Boolean HasAtToken(String input)
        {
            return input.ToLower().Contains("at");
        }

        private Tuple<String, int> DetermineItemName(String[] tokens, int startIndex, bool isImported)
        {//returns a tuple that has the concatenated String as well as the index of the "at"
            StringBuilder sb = new StringBuilder();
            if (isImported) { sb.Append("Imported "); }
            for (int i = startIndex; i < tokens.Length; i++)
            {
                String token = tokens[i];
                if (token.Equals("at"))
                {
                    sb.Length -= 1;
                    String concatString = sb.ToString(); //remove last space
                    return new Tuple<string, int>(concatString, i); 
                }
                sb.Append(token);
                sb.Append(" ");
            }
            return null; //Something went wrong if we hit here.
        }

        private double GetBasePrice(String token)
        {
            try
            {
                return Double.Parse(token);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{token}' as a Double. Wrong Format. Try Again.");
                throw new FormatException();
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Unable to parse '{token}' as a Double. Too Large of a value. Try Again.");
                throw new OverflowException();
            }
        }

        private int GetQuantity(String token)
        {
            try
            {
                return Int32.Parse(token);
            }catch(FormatException)
            {
                Console.WriteLine($"Unable to parse '{token}' as a Quantity. Try Again.");
                throw new FormatException();
            }

        }

        private bool HasImportedToken(String token)
        {
            return token.ToLower().Equals("imported");
        }

        public Outputter GetOutputter()
        {
            return this.output;
        }
        
    }
}
