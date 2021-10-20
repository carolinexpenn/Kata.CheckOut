using CheckOutKata.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutKata.Tests
{
    [TestClass]
    public class CheckOutShould
    {
        [Test]
        [TestCaseSource (typeof(CheckOutTestData), "GetSetUpData")]
        public void Should_Scan_Item_At_CheckOut(List<ProductItem> productItems, ProductDiscounts productDiscounts)
        {
            var checkout = new CheckOut(productItems, productDiscounts);

            var scannedItem = new ScannedItem("A99", 1);

            checkout.Scan(scannedItem);

            var checkoutTotal = checkout.GetTotal();

            //No calcuation, just a scanned item
            NUnit.Framework.Assert.AreEqual(checkoutTotal, 0.50M);
        }

        [Test]
        [TestCaseSource(typeof(CheckOutTestData), "GetSetUpData")]
        public void Should_Apply_Discount(List<ProductItem> productItems, ProductDiscounts productDiscounts)
        {
            var checkout = new CheckOut(productItems, productDiscounts);
               
            var scannedItem = new ScannedItem("A99", 3);
            checkout.Scan(scannedItem);

            scannedItem = new ScannedItem("B15", 2);
            checkout.Scan(scannedItem);

            var checkoutTotal = checkout.GetTotal();

            //A99 = 1.30, B15 = 0.45, so total with discount should be 1.75
            NUnit.Framework.Assert.AreEqual(checkoutTotal,1.75M);
        }

        [Test]
        [TestCaseSource(typeof(CheckOutTestData), "GetSetUpData")]
        public void Should_Apply_Discount_And_StandardPrice(List<ProductItem> productItems, ProductDiscounts productDiscounts)
        {
            var checkout = new CheckOut(productItems, productDiscounts);

            var scannedItem = new ScannedItem("A99", 4);
            checkout.Scan(scannedItem);

            scannedItem = new ScannedItem("B15", 2);
            checkout.Scan(scannedItem);

            var checkoutTotal = checkout.GetTotal();

            //A99 = 3 @ 1.30 + 1 @  50p, B15 = 0.45, so total with discount should be 2.25
            NUnit.Framework.Assert.AreEqual(checkoutTotal, 2.25M);
        }



        [Test]
        [TestCaseSource(typeof(CheckOutTestData), "GetSetUpData")]
        public void Should_Get_Total_Price_WithOffers(List<ProductItem> productItems, ProductDiscounts productDiscounts)
        {
            var checkout = new CheckOut(productItems, productDiscounts);

            var scannedItem = new ScannedItem("A99", 5);
            checkout.Scan(scannedItem);

            var checkoutTotal = checkout.GetTotal();

            //2 at standard price of 50p + 3 for the discount cost of £1.30
            NUnit.Framework.Assert.AreEqual(checkoutTotal, 2.30M);
        }

        [Test]
        [TestCaseSource(typeof(CheckOutTestData), "GetSetUpData")]
        public void Should_Allow_New_Discounts(List<ProductItem> productItems, ProductDiscounts discounts)
        {
            discounts.UpdateProductDiscount(new Discount("C40", 2, .40M));

            var checkout = new CheckOut(productItems, discounts);

            var scannedItem = new ScannedItem("C40", 2);
            checkout.Scan(scannedItem);

            var checkoutTotal = checkout.GetTotal();

            //2 at discount price of 40p
            NUnit.Framework.Assert.AreEqual(checkoutTotal, 0.40M);
        }
    }
}
