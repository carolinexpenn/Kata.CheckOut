using CheckOutKata.Classes;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutKata.Tests
{
    public static class CheckOutTestData
    {
        /// <summary>
        /// Gets the list of product items and discounts for the tests
        /// </summary>
        /// <returns>An IEnumerable list of Test Data</returns>
        public static IEnumerable GetSetUpData()
        {
            var productItems = new List<ProductItem>
                {
                    new ProductItem("A99", 0.50M),
                    new ProductItem("B15", 0.30M),
                    new ProductItem("C40", 0.60M)
                };

            var discounts = new List<Discount>
                {
                    new Discount("A99", 3, 1.30M),
                    new Discount("B15", 2, 0.45M)
                };

            var productDiscounts = new ProductDiscounts();
            productDiscounts.AddProductDiscounts(discounts);

            yield return new TestCaseData(productItems, productDiscounts);
        }
    }
}
