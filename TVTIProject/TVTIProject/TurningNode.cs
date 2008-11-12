using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GorgonLibrary;

namespace TVTIProject
{
    public enum TurningOptions { 
        north,
        east,
        south,
        west,
    }

    /// <summary>
    /// Representa un nodo que permite girar al personaje en la escena
    /// </summary>
    public class TurningNode : SceneNode
    {
        private LinkedList<TurningOptions> possibleTurningOptions;
        private TurningOptions turnedTo;

        public TurningNode(Vector2D position) : base(position) {
            possibleTurningOptions = new LinkedList<TurningOptions>();
        }

        public LinkedList<TurningOptions> PossibleTurningOptions {
            get { return possibleTurningOptions; }
            set {
                possibleTurningOptions = value;
                turnedTo = possibleTurningOptions.First<TurningOptions>();
            }
        }

        /// <summary>
        /// Gira la flecha hacia la siguiente posicion posible.
        /// </summary>
        private void turn() {
            bool returnNext = false;
            foreach (TurningOptions to in possibleTurningOptions) {
                if (returnNext) {
                    turnedTo = to;
                }
                if (to == turnedTo) {
                    if (to == possibleTurningOptions.Last<TurningOptions>())
                    {
                        turnedTo = possibleTurningOptions.First<TurningOptions>();
                        return;
                    }
                    else {
                        returnNext = true;
                    }
                }
            }
        }

        public override void onClick()
        {
            turn();
            throw new NotImplementedException();
        }

        public override void onVisit()
        {
            throw new NotImplementedException();
        }

    }
}
