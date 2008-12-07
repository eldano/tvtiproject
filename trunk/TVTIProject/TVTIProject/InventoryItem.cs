using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TVTIProject
{

    public enum ItemTypes {
        cursor,
        trapo,
        extintor,
        tapa,
        contenedor,
    }

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

        public ItemTypes tipo
        {
            get;
            set;
        }

        public InventoryItem(int stock, ItemTypes tipo)
        {
            Stock = stock;
            this.tipo = tipo;
        }
    }
}
