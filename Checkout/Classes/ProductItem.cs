using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutKata.Classes
{
    public class ProductItem 
    {
        public string SKU { get; set; }
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// The Product Item
        /// </summary>
        /// <param name="sku">unique identifier</param>
        /// <param name="unitPrice">the price per unit</param>
        public ProductItem(string sku, decimal unitPrice)
        {
            this.SKU = sku;
            this.UnitPrice = unitPrice;
        }
    }
}
