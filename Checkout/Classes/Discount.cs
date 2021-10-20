using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutKata.Classes
{
    public class Discount 
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public decimal OfficePrice { get; set; }

        /// <summary>
        /// The Discount object
        /// </summary>
        /// <param name="sku">unique id</param>
        /// <param name="quantity">amount for discount to apply</param>
        /// <param name="offerPrice">the discount</param>
        public Discount(string sku, int quantity, decimal offerPrice)
        {
            this.SKU = sku;
            this.Quantity = quantity;
            this.OfficePrice = offerPrice;
        }


    }
}
