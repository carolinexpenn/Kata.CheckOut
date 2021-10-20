using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutKata.Classes
{
   public class ProductDiscounts
    {
        public List<Discount> Discounts = new List<Discount>();

        /// <summary>
        /// Add a list of discounts to ProductDiscount
        /// </summary>
        /// <param name="discounts"></param>
        /// <returns>the discount list</returns>
        public List<Discount> AddProductDiscounts(List<Discount> discounts)
        {
            this.Discounts.AddRange(discounts);

            return this.Discounts;
        }

        /// <summary>
        /// Will add or update the list of discounts
        /// </summary>
        /// <param name="discount">the new discount</param>
        /// <returns>the discount list</returns>
        public List<Discount> UpdateProductDiscount(Discount discount)
        {
            this.Discounts.RemoveAll(e => e.SKU == discount.SKU);

            this.Discounts.Add(discount);

            return this.Discounts;
        }
    }
}
