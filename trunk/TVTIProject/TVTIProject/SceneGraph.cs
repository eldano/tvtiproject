using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GorgonLibrary;

namespace TVTIProject
{

    public class SceneGraph
    {
        private LinkedList<SceneNode> nodes;

        public SceneGraph() {
            nodes = new LinkedList<SceneNode>();
        }

        public void addNode(SceneNode node) {
            nodes.AddLast(node);
        }

        /// <summary>
        /// Crea una arista en el grafo desde node1 hacia node2 con direccion dir.
        /// </summary>
        /// <param name="node1">Nodo origen</param>
        /// <param name="node2">Nodo destino</param>
        /// <param name="dir">Direccion desde node1 en la que se encuentra node2.</param>
        public void createEdge(SceneNode node1, SceneNode node2, Direction dir) {
            node1.addNeighbor(dir, node2);
        }
    }
}
