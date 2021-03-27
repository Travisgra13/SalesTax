using System;
using System.Collections.Generic;
using System.Text;

namespace Item
{
    class Medical : Item
    {
        public Medical(String itemName, double basePrice, bool imported) : base(itemName, basePrice, imported) { }

        public override double GetSalesTaxValue()
        {
            return 0.0;
        }
    }
}
