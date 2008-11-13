using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GorgonLibrary;

namespace TVTIProject
{

    /// <summary>
    /// Representa un nodo que permite girar al personaje en la escena
    /// </summary>
    public class TurningNode : SceneNode
    {
        private LinkedList<Direction> possibleTurningDirections;
        private Direction turnedTo;

        public TurningNode(Vector2D position) : base(position) {
            possibleTurningDirections = new LinkedList<Direction>();
        }

        public LinkedList<Direction> PossibleTurningOptions {
            get { return possibleTurningDirections; }
            set {
                possibleTurningDirections = value;
                turnedTo = possibleTurningDirections.First<Direction>();
            }
        }

        /// <summary>
        /// Gira la flecha hacia la siguiente posicion posible.
        /// </summary>
        private void turn() {
            bool returnNext = false;
            foreach (Direction to in possibleTurningDirections) {
                if (returnNext) {
                    turnedTo = to;
                }
                if (to == turnedTo) {
                    if (to == possibleTurningDirections.Last<Direction>())
                    {
                        turnedTo = possibleTurningDirections.First<Direction>();
                        return;
                    }
                    else {
                        returnNext = true;
                    }
                }
            }
        }

        public override void MouseClick(InventoryItem item)
        {
            turn();
            throw new NotImplementedException();
        }

        public override void CharacterVisit(Character character)
        {
            character.Direction = turnedTo;

            SceneNode nodeDest;
            this.NeighborNodes.TryGetValue(character.Direction, out nodeDest);
            character.DirectionVector = nodeDest.Position - this.Position;

            throw new NotImplementedException();
        }

    }
}
