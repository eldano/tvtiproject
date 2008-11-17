﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GorgonLibrary;
using GorgonLibrary.Graphics;

namespace TVTIProject
{
    enum HazardState { 
        hazard,
        solved,
    }

    /// <summary>
    /// Representa un nodo de tipo Hazard de la escena
    /// </summary>
    public class HazardNode : SceneNode
    {
        private HazardState state;

        public HazardNode(Vector2D position, Sprite sprite) : base(position, sprite) {
            state = HazardState.hazard;
        }

        private void trySolve(InventoryItem item) {
            //TODO: Se podría guardar el nombre del elemento que lo resuelve y compara el nombre aquí.
            //Tal vez la operacion reciba un string en lugar de un item
        }

        public override void MouseClick(InventoryItem item)
        {
            trySolve(item);
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
