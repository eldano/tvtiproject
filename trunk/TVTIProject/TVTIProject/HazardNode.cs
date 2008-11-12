using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GorgonLibrary;

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

        public HazardNode(Vector2D position) : base(position) {
            state = HazardState.hazard;
        }

        private void solve(InventoryItem item) { 
            //TODO: Se podría guardar el nombre del elemento que lo resuelve y compara el nombre aquí.
            //Tal vez la operacion reciba un string en lugar de un item
        }

        public override void onClick()
        {
            throw new NotImplementedException();
        }

        public override void onVisit()
        {
            throw new NotImplementedException();
        }

    }
}
