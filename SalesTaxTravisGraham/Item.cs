using System;
using System.Collections.Generic;
using System.Text;

namespace Item
{
    public abstract class Item
    {
        protected const double IMPORT_TAX_RATE = 0.05;
        protected const double SALES_TAX_RATE = 0.10;
        protected const int ROUND_TAX_NEAREST_K = 20; //round to nearest .05
        //protected const double ROUND_SALES_TAX_NEAREST_K = .01;

        protected bool imported;
        protected double basePrice;
        protected int quantity;
        protected String itemName;

        public Item(String itemName, double basePrice, int quantity, bool imported)
        {
            this.itemName = itemName;
            this.basePrice = basePrice;
            this.quantity = quantity;
            this.imported = imported;
        }

        public double GetTotalPrice()
        {
            return (this.basePrice + GetImportedTaxValue() + GetSalesTaxValue()) * quantity;
        }

        public abstract double GetSalesTaxValue();

        protected double GetImportedTaxValue()
        {
            if (!this.imported)
            {
                return 0.0;
            }
            //double preRoundValue = basePrice * IMPORT_TAX_RATE * quantity;
            double preRoundValue = basePrice * IMPORT_TAX_RATE;
            return preRoundValue;
        }

        protected double RoundUpValue(double value, int places)
        {
            return Math.Round((value * places)) / places;
        }

        public double GetBasePrice()
        {
            return this.basePrice;
        }

        public String GetItemName()
        {
            return this.itemName;
        }

        public bool isImported()
        {
            return this.imported;
        }

        public int GetQuantity()
        {
            return this.quantity;
        }

    }
}
