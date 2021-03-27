using System;
using System.Collections.Generic;
using System.Text;

namespace Item
{
    class TaxableItem : Item
    {
        public TaxableItem(String itemName, double basePrice, int quantity, bool imported) : base(itemName, basePrice, quantity, imported) { }

        public override double GetSalesTaxValue()
        {
            //double preRoundValue = basePrice * SALES_TAX_RATE * quantity;
            double preRoundValue = basePrice * SALES_TAX_RATE;
            return RoundUpValue(preRoundValue, ROUND_TAX_NEAREST_K);
        }
    }
}
