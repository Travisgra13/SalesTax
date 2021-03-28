using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxTravisGraham
{
    public class Outputter : Dictionary<String, List<Item.Item>>
    {

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            double totalSalesTax = 0.0;
            double totalPrice = 0.0;
            foreach (String key in this.Keys)
            {
                int totalQuantity = 0;
                double basePrice = 0.0;
                double price = 0.0;
                List<Item.Item> items = this[key];
                for (int i = 0; i < items.Count; i++)
                {
                    Item.Item item = items[i];
                    int quantity = item.GetQuantity();
                    totalSalesTax += item.GetSalesTaxValue() * quantity;
                    totalSalesTax += item.GetImportedTaxValue() * quantity;
                    totalPrice += item.GetTotalPrice();
                    price += item.GetTotalPrice();
                    totalQuantity += quantity;
                    basePrice = item.GetBasePrice();
                }
                sb.AppendLine(buildItemString(key, basePrice, price, totalQuantity));
            }
            sb.AppendLine("Sales Taxes: " + $"{totalSalesTax:0.00}");
            sb.AppendLine("Total: " + $"{totalPrice:0.00}");
            return sb.ToString();
        }

        private String buildItemString(String itemName, double basePrice, double totalPrice, int totalQuantity)
        {
            StringBuilder sb = new StringBuilder();
            if (totalQuantity == 1)
            {
                sb.Append(itemName + ": " + $"{totalPrice:0.00}");
            }
            else
            {
                sb.Append(itemName + ": " + $"{totalPrice:0.00}" + " " + buildQuantityString(totalQuantity, basePrice));
            }
            return sb.ToString();
        }

        private String buildQuantityString(int quantity, double basePrice)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(" + quantity + " @ " + $"{basePrice:0.00}" + ")");
            return sb.ToString();
        }



    }
}
