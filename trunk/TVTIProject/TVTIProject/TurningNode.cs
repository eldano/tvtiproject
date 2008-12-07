using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GorgonLibrary;
using GorgonLibrary.Graphics;

namespace TVTIProject
{

    /// <summary>
    /// Representa un nodo que permite girar al personaje en la escena
    /// </summary>
    public class TurningNode : SceneNode
    {
        private LinkedList<Direction> possibleTurningDirections;
        private Direction turnedTo;

        public TurningNode(Vector2D position, Sprite sprite) : base(position, sprite) {
            possibleTurningDirections = new LinkedList<Direction>();
        }

        public void addPossibleTurningDirection(Direction dir) {
            possibleTurningDirections.AddLast(dir);
            turnedTo = possibleTurningDirections.First<Direction>();
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
            System.Windows.Forms.MessageBox.Show("Click on node");
        }

        public override void CharacterVisit(Character character)
        {
            character.NodeDest = this.NeighborNodes[turnedTo];
        }

        public override void Draw(float dtime)
        {
            switch (turnedTo) { 
                case Direction.north:
                    this.Sprite.Animations["north"].Advance(dtime);
                    break;
                case Direction.east:
                    this.Sprite.Animations["east"].Advance(dtime);
                    break;
                case Direction.south:
                    this.Sprite.Animations["south"].Advance(dtime);
                    break;
                case Direction.west:
                    this.Sprite.Animations["west"].Advance(dtime);
                    break;
            }

            Sprite.Draw();
        }
    }
}
