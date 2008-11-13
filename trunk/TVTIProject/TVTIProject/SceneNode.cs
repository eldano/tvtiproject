using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GorgonLibrary.Graphics;
using GorgonLibrary;

namespace TVTIProject
{
    /// <summary>
    /// Clase que representa un nodo del grafo de escena
    /// </summary>
    public abstract class SceneNode
    {
        /// <summary>
        /// Posicion absoluta del nodo.
        /// </summary>
        public Vector2D Position
        {
            get;
            set;
        }

        /// <summary>
        /// Nodo adyacente al norte.
        /// </summary>
        public Dictionary<Direction, SceneNode> NeighborNodes
        {
            get;
            set;
        }

        /// <param name="position">Posicion absoluta del nodo.</param>
        public SceneNode(Vector2D position) {
            this.Position = position;
            NeighborNodes = new Dictionary<Direction, SceneNode>();
        }

        public void addNeighbor(Direction dir, SceneNode node) {
            NeighborNodes.Add(dir, node);
        }

        /// <summary>
        /// Ejecuta la accion que debe realizar el nodo al hacer click cuando está seleccionado un item en el inventario.
        /// </summary>
        /// <param name="item">Item seleccionado</param>
        public abstract void MouseClick(InventoryItem item);

        /// <summary>
        /// Ejecuta la accion que debe realizar cuando el personaje llega hasta el.
        /// </summary>
        public abstract void CharacterVisit(Character character);

    }

}
