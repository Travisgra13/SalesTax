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
    }
}
