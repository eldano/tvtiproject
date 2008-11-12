using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TVTIProject
{
    /// <summary>
    /// Clase que representa una arista del grafo de escena
    /// </summary>
    public class SceneEdge
    {
        public SceneNode Node1
        {
            get;
            set;
        }

        public SceneNode Node2
        {
            get;
            set;
        }

        public SceneEdge(SceneNode node1, SceneNode node2) {
            Node1 = node1;
            Node2 = node2;
            
        }


    }
}
