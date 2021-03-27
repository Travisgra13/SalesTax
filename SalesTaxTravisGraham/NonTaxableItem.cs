using System;
using System.Collections.Generic;
using System.Text;

namespace Item
{
    class NonTaxableItem : Item
    {
        public NonTaxableItem(String itemName, double basePrice, bool imported) : base(itemName, basePrice, imported) { }

        public override double GetSalesTaxValue()
        {
            return 0.0;
        }
    }
}
