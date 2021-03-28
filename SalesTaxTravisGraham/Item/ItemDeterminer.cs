using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxTravisGraham
{
    public class ItemDeterminer
    {
        ISet<String> nonTaxableKeyWords = new HashSet<String>();

        public ItemDeterminer()
        {
            InitializeKeyWords();
        }

        private void InitializeKeyWords()
        { //food || book || medicine
            nonTaxableKeyWords.Add("book");
            nonTaxableKeyWords.Add("chocolate");
            nonTaxableKeyWords.Add("pill");
        }

        public Item.Item Itemize(String itemName, double basePrice, int quantity, bool imported)
        {
            String compString = itemName.ToLower();
            foreach (String keyWord in nonTaxableKeyWords)
            {
                if (compString.Contains(keyWord))
                {
                    return new Item.NonTaxableItem(itemName, basePrice, quantity, imported);
                }
            }

            return new Item.TaxableItem(itemName, basePrice, quantity, imported);
        }





    }
}
