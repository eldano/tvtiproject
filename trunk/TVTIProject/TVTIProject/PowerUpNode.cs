using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GorgonLibrary;
using GorgonLibrary.Graphics;

namespace TVTIProject
{
    /// <summary>
    /// Representa un nodo de tipo PowerUp de la escena
    /// </summary>
    public class PowerUpNode : SceneNode
    {
        public InventoryItem InventoryItem
        {
            get;
            set;
        }

        public PowerUpNode(Vector2D position, Sprite sprite, InventoryItem item) : base(position, sprite) {
            InventoryItem = item;
        }

        public override void MouseClick(InventoryItem item)
        {
            throw new NotImplementedException();
        }

        public override void CharacterVisit(Character character)
        {
            throw new NotImplementedException();
        }

        public override void Draw(float dtime)
        {
            throw new NotImplementedException();
        }
    }
}
