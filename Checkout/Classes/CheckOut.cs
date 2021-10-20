using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutKata.Classes
{
    /// <summary>
    /// CheckOut Class inherits from interface with two methods, GetTotal and Scan.
    /// </summary>
    public class CheckOut : ICheckOut
    {
        private List<ScannedItem> scannedItems;
        private ProductDiscounts productDiscounts;
        private List<ProductItem> productItems;

        /// <summary>
        /// CheckOut Constructor.
        /// Could take interfaces resolved by dependency injection
        /// </summary>
        /// <param name="productItems"></param>
        /// <param name="discounts"></param>
        public CheckOut(List<ProductItem> productItems, ProductDiscounts productDiscounts)
        {
            this.scannedItems = new List<ScannedItem>();
            this.productItems = productItems;
            this.productDiscounts = productDiscounts;
        }

        /// <summary>
        /// Calculates the Total from Price and Discounts (where applicable).
        /// </summary>
        /// <returns>A decimal value</returns>
        public decimal GetTotal()
        {
            decimal totalPrice = 0;

            foreach (var scannedItem in scannedItems)
            {
                var discount = productDiscounts.Discounts?.SingleOrDefault(e => e.SKU == scannedItem.SKU);
                var unitPrice = productItems.SingleOrDefault(e => e.SKU == scannedItem.SKU).UnitPrice;

                if (discount == null || scannedItem.Quantity < discount.Quantity) //there are no discounts to apply
                {
                    totalPrice += unitPrice * scannedItem.Quantity;
                }
                else
                {
                    var itemPrice = (scannedItem.Quantity - discount.Quantity) * unitPrice; //number of items not at discount * unit price.
                    totalPrice += itemPrice + discount.OfficePrice;
                }
            }

            return totalPrice;
        }

        /// <summary>
        /// Either adds a new scannedItem or increments an existing one
        /// </summary>
        /// <param name="scannedItem">the item that's been scanned</param>
        public void Scan(ScannedItem scannedItem)
        {
            if (scannedItems.Any(e => e.SKU.Equals(scannedItem.SKU)))
            {
                scannedItems.Single(x => x.SKU.Equals(scannedItem.SKU)).Quantity += scannedItem.Quantity;
            }
            else
            {
                scannedItems.Add(scannedItem);
            }
        }
    }
}
