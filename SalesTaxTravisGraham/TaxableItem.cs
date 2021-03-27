using System;
using System.Collections.Generic;
using System.Text;

namespace Item
{
    class TaxableItem : Item
    {
        public TaxableItem(String itemName, double basePrice, bool imported) : base(itemName, basePrice, imported) { }

        public override double GetSalesTaxValue()
        {
            double preRoundValue = basePrice * SALES_TAX_RATE;
            return RoundUpValue(preRoundValue);
        }
    }
}
