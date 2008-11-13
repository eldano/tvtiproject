using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TVTIProject
{
    /// <summary>
    /// Representa un tipo de item del inventario.
    /// </summary>
    public class InventoryItem
    {
        public int Stock
        {
            get;
            set;
        }

        /// <param name="stock">Cantidad de items de este tipo. Negativo para items inagotables</param>
        public InventoryItem(int stock) {
            Stock = stock;
        }
    }
}
