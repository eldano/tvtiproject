using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GorgonLibrary;
using GorgonLibrary.Graphics;

using System.Drawing;

namespace TVTIProject
{

    class MenuItem {

        private int width = 40;
        private int height = 40;

        public ItemTypes tipoItem;
        public int cantidad;
        public Rectangle rectangle;

        public MenuItem(ItemTypes tipoItem, int cantidad, int minX, int minY) {
            this.tipoItem = tipoItem;
            this.cantidad = cantidad;

            rectangle = new Rectangle(minX, minY, width, height);
        }

        public bool contains(int X, int Y) {
            return (rectangle.Contains(X,Y));
        }
    }

    class MenuLateral
    {

        public Sprite Sprite
        {
            get;
            set;
        }

        public MenuItem itemTrapo;
        public MenuItem itemContenedor;
        public MenuItem itemTapa;
        public MenuItem itemExtintor;

        public MenuLateral(Sprite sprite) {
            this.Sprite = sprite;

            Vector2D pos = new Vector2D(600, 0);

            sprite.Position = pos;

            itemTapa = new MenuItem(ItemTypes.tapa, 2, (int)pos.X + 10, 20);
            itemContenedor = new MenuItem(ItemTypes.contenedor, 2, (int)pos.X + 10, 60);
            itemTrapo = new MenuItem(ItemTypes.trapo, 2, (int)pos.X + 10, 100);
            itemExtintor = new MenuItem(ItemTypes.extintor, 2, (int)pos.X + 10, 140);
        }

        public bool Contains(int X, int Y) {
            Rectangle r = new Rectangle((int)Sprite.Position.X, (int)Sprite.Position.Y, (int)Sprite.Width, (int)Sprite.Height);
            return r.Contains(X, Y);
        }

        public void Click(int x, int y, InventoryItem cursor) {
            if (itemTapa.contains(x, y) && itemTapa.cantidad != 0) {
                cursor.tipo = itemTapa.tipoItem;
            }
            if (itemContenedor.contains(x, y) && itemContenedor.cantidad != 0)
            {
                cursor.tipo = itemContenedor.tipoItem;
            }
            if (itemTrapo.contains(x, y) && itemTrapo.cantidad != 0)
            {
                cursor.tipo = itemTrapo.tipoItem;
            }
            if (itemExtintor.contains(x, y) && itemExtintor.cantidad != 0)
            {
                cursor.tipo = itemExtintor.tipoItem;
            }
        }

        public void Draw(float dtime)
        {
            Sprite.Draw();
        }
    }
}
