﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GorgonLibrary;

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

        public PowerUpNode(Vector2D position, InventoryItem item) : base(position) {
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

    }
}