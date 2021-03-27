using System;
using System.Collections.Generic;
using System.Text;

namespace Item
{
    class Book : Item
    {
        public Book(String itemName, double basePrice, bool imported) : base(itemName, basePrice, imported) { }

        public override double GetSalesTaxValue()
        {
            return 0.0;
        }
    }
}
