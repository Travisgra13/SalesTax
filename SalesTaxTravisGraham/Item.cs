﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Item
{
    public abstract class Item
    {
        protected const double IMPORT_TAX_RATE = 0.05;
        protected const double SALES_TAX_RATE = 0.10;

        protected bool imported;
        protected double basePrice;
        protected String itemName;

        public Item(String itemName, double basePrice, bool imported)
        {
            this.itemName = itemName;
            this.basePrice = basePrice;
            this.imported = imported;
        }

        public String GetItemType()
        {
            return this.GetType().Name;
        }

        public abstract double GetSalesTaxValue();

        protected double GetImportedTaxValue()
        {
            double preRoundValue = basePrice * IMPORT_TAX_RATE;
            return RoundUpValue(preRoundValue);
        }

        protected double RoundUpValue(double value)
        {
            //todo fixme
            return value;
        }

    }
}
