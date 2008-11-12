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

        private LinkedList<SceneEdge> edges;

        public SceneGraph() {
            nodes = new LinkedList<SceneNode>();
            edges = new LinkedList<SceneEdge>();
        }



    }
}
