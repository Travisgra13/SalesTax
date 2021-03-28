using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTaxTravisGraham;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SalesTaxUnitTests
{
    [TestClass]
    public class UnitTestsSalesTax
    {

        private Tuple<String, String> normalizeExpectedActual(String expected, String actual)
        {
            string normalizedExpected = Regex.Replace(expected, @"\s", ""); //ignore whitespace
            string normalizedActual = Regex.Replace(actual, @"\s", ""); //ignore whitespace
            return new Tuple<string, string>(normalizedExpected, normalizedActual);
        }

        [TestMethod]
        public void TestCase1()
        {
            Item.Item book1 = new Item.NonTaxableItem("Book", 12.49, 1, false);
            Item.Item book2 = new Item.NonTaxableItem("Book", 12.49, 1, false);
            Item.Item music = new Item.TaxableItem("Music CD", 14.99, 1, false);
            Item.Item chocolate = new Item.NonTaxableItem("Chocolate bar", 0.85, 1, false);

            Outputter outputter = new Outputter();
            List<Item.Item> bookList = new List<Item.Item>();
            bookList.Add(book1);
            bookList.Add(book2);

            List<Item.Item> musicList = new List<Item.Item>();
            musicList.Add(music);

            List<Item.Item> chocolateList = new List<Item.Item>();
            chocolateList.Add(chocolate);

            outputter.Add(book1.GetItemName(), bookList);
            outputter.Add(music.GetItemName(), musicList);
            outputter.Add(chocolate.GetItemName(), chocolateList);

            string expected = "Book: 24.98 (2 @ 12.49)\n" +
                                "Music CD: 16.49\n" +
                                "Chocolate bar: 0.85\n" +
                                "Sales Taxes: 1.50\n" +
                                "Total: 42.32\n";
            Tuple<String, String> result = normalizeExpectedActual(expected, outputter.ToString());
            Assert.IsTrue(String.Equals(result.Item1, result.Item2, StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void TestCase1UsingQuantityGreaterThan1()
        {
            Item.Item book1 = new Item.NonTaxableItem("Book", 12.49, 2, false);
            Item.Item music = new Item.TaxableItem("Music CD", 14.99, 1, false);
            Item.Item chocolate = new Item.NonTaxableItem("Chocolate bar", 0.85, 1, false);

            Outputter outputter = new Outputter();
            List<Item.Item> bookList = new List<Item.Item>();
            bookList.Add(book1);
            List<Item.Item> musicList = new List<Item.Item>();
            musicList.Add(music);

            List<Item.Item> chocolateList = new List<Item.Item>();
            chocolateList.Add(chocolate);

            outputter.Add(book1.GetItemName(), bookList);
            outputter.Add(music.GetItemName(), musicList);
            outputter.Add(chocolate.GetItemName(), chocolateList);

            string expected = "Book: 24.98 (2 @ 12.49)\n" +
                                "Music CD: 16.49\n" +
                                "Chocolate bar: 0.85\n" +
                                "Sales Taxes: 1.50\n" +
                                "Total: 42.32\n";
            Tuple<String, String> result = normalizeExpectedActual(expected, outputter.ToString());
            Assert.IsTrue(String.Equals(result.Item1, result.Item2, StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void TestCase2()
        {
            Item.Item importedFood = new Item.NonTaxableItem("Imported box of chocolates", 10.00, 1, true);
            Item.Item importedPerfume = new Item.TaxableItem("Imported bottle of perfume", 47.50, 1, true);

            Outputter outputter = new Outputter();
            List<Item.Item> importedFoodList = new List<Item.Item>();
            importedFoodList.Add(importedFood);
            List<Item.Item> importedPerfumeList = new List<Item.Item>();
            importedPerfumeList.Add(importedPerfume);

            outputter.Add(importedFood.GetItemName(), importedFoodList);
            outputter.Add(importedPerfume.GetItemName(), importedPerfumeList);
            string expected = "Imported box of chocolates: 10.50\n" +
                                "Imported bottle of perfume: 54.65\n" +
                                "Sales Taxes: 7.65\n" +
                                "Total: 65.15\n";
            Tuple<String, String> result = normalizeExpectedActual(expected, outputter.ToString());
            Assert.IsTrue(String.Equals(result.Item1, result.Item2, StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void TestCase3()
        {
            Item.Item importedPerfume = new Item.TaxableItem("Imported bottle of perfume", 27.99, 1, true);
            Item.Item unimportedPerfume = new Item.TaxableItem("Bottle of perfume", 18.99, 1, false);
            Item.Item medicine = new Item.NonTaxableItem("Packet of headache pills", 9.75, 1, false);
            Item.Item importedFood1 = new Item.NonTaxableItem("Imported box of chocolates", 11.25, 1, true);
            Item.Item importedFood2 = new Item.NonTaxableItem("Imported box of chocolates", 11.25, 1, true);

            Outputter outputter = new Outputter();
            List<Item.Item> importedFoodList = new List<Item.Item>();
            importedFoodList.Add(importedFood1);
            importedFoodList.Add(importedFood2);

            List<Item.Item> importedPerfumeList = new List<Item.Item>();
            importedPerfumeList.Add(importedPerfume);

            List<Item.Item> unimportedPerfumeList = new List<Item.Item>();
            unimportedPerfumeList.Add(unimportedPerfume);

            List<Item.Item> medicineList = new List<Item.Item>();
            medicineList.Add(medicine);

            outputter.Add(importedPerfume.GetItemName(), importedPerfumeList);
            outputter.Add(unimportedPerfume.GetItemName(), unimportedPerfumeList);
            outputter.Add(medicine.GetItemName(), medicineList);
            outputter.Add(importedFood1.GetItemName(), importedFoodList);

            string expected = "Imported bottle of perfume: 32.19\n" +
                                "Bottle of perfume: 20.89\n" +
                                "Packet of headache pills: 9.75\n" +
                                "Imported box of chocolates: 23.70(2 @ 11.25)\n" +
                                "Sales Taxes: 7.30\n" +
                                "Total: 86.53\n";
            Tuple<String, String> result = normalizeExpectedActual(expected, outputter.ToString());
            Assert.IsTrue(String.Equals(result.Item1, result.Item2, StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void TestCase3WithQuantities()
        {
            Item.Item importedPerfume = new Item.TaxableItem("Imported bottle of perfume", 27.99, 1, true);
            Item.Item unimportedPerfume = new Item.TaxableItem("Bottle of perfume", 18.99, 1, false);
            Item.Item medicine = new Item.NonTaxableItem("Packet of headache pills", 9.75, 1, false);
            Item.Item importedFood1 = new Item.NonTaxableItem("Imported box of chocolates", 11.25, 2, true);

            Outputter outputter = new Outputter();
            List<Item.Item> importedFoodList = new List<Item.Item>();
            importedFoodList.Add(importedFood1);

            List<Item.Item> importedPerfumeList = new List<Item.Item>();
            importedPerfumeList.Add(importedPerfume);

            List<Item.Item> unimportedPerfumeList = new List<Item.Item>();
            unimportedPerfumeList.Add(unimportedPerfume);

            List<Item.Item> medicineList = new List<Item.Item>();
            medicineList.Add(medicine);

            outputter.Add(importedPerfume.GetItemName(), importedPerfumeList);
            outputter.Add(unimportedPerfume.GetItemName(), unimportedPerfumeList);
            outputter.Add(medicine.GetItemName(), medicineList);
            outputter.Add(importedFood1.GetItemName(), importedFoodList);

            string expected = "Imported bottle of perfume: 32.19\n" +
                                "Bottle of perfume: 20.89\n" +
                                "Packet of headache pills: 9.75\n" +
                                "Imported box of chocolates: 23.70(2 @ 11.25)\n" +
                                "Sales Taxes: 7.30\n" +
                                "Total: 86.53\n";
            Tuple<String, String> result = normalizeExpectedActual(expected, outputter.ToString());
            Assert.IsTrue(String.Equals(result.Item1, result.Item2, StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void TestCaseEmpty()
        {

            Outputter outputter = new Outputter();
            string expected =   "Sales Taxes: 0.00\n" +
                                "Total: 0.00\n";
            Tuple<String, String> result = normalizeExpectedActual(expected, outputter.ToString());
            Assert.IsTrue(String.Equals(result.Item1, result.Item2, StringComparison.OrdinalIgnoreCase));
        }
    }
}
