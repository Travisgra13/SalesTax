using System;
using System.Collections.Generic;
using System.Text;

namespace Item
{
    public class NonTaxableItem : Item
    {
        public NonTaxableItem(String itemName, double basePrice, int quantity, bool imported) : base(itemName, basePrice, quantity, imported) { }

        public override double GetSalesTaxValue()
        {
            return 0.0;
        }
    }
}
