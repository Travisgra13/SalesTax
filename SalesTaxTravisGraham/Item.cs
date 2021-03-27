using System;
using System.Collections.Generic;
using System.Text;

namespace Item
{
    public abstract class Item
    {
        protected bool imported;
        protected double basePrice;
        protected String itemName;

        public Item(String itemName, double basePrice, bool imported)
        {
            this.itemName = itemName;
            this.basePrice = basePrice;
            this.imported = imported;
        }



        public String getItemType()
        {
            return this.GetType().Name;
        }

        public abstract double getSalesTaxValue();

        protected double roundSalesTax(double salesTax)
        {
            //todo fixme
            return basePrice;
        }

    }
}
