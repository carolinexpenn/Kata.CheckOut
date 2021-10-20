using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutKata.Classes
{
    public class ScannedItem 
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }

        public ScannedItem()
        { }

        /// <summary>
        /// Scanned Item
        /// </summary>
        /// <param name="sku">unique identifier</param>
        /// <param name="quantity">number of items, default is 1</param>
        public ScannedItem(string sku, int quantity = 1)
        {
            this.SKU = sku;
            this.Quantity = quantity; 
        }
    }
}
