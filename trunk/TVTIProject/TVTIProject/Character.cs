using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GorgonLibrary;
using GorgonLibrary.Graphics;

namespace TVTIProject
{
    public class Character
    {
        public Sprite Sprite
        {
            get;
            set;
        }

        public Vector2D Position
        {
            get;
            set;
        }

        public float Speed
        {
            get;
            set;
        }

        private Animation activeAnimation;

        private SceneNode nodeSrc;
        private SceneNode nodeDest;

        /// <summary>
        /// Se obtiene o setea el nodo destino.
        /// Al setearlo se activa también la nueva animación y la nueva dirección de movimiento.
        /// </summary>
        public SceneNode NodeDest
        {
            get { return nodeDest; }
            set {
                nodeSrc = nodeDest;
                nodeDest = value;

                directionVector = nodeDest.Position - this.Position;
                directionVector.Normalize();

                activeAnimation.AnimationState = AnimationState.Stopped;

                if (nodeSrc == null)
                {
                    activeAnimation = Sprite.Animations["walkEast"];
                }
                else
                {
                    if (nodeSrc.NeighborNodes.ContainsKey(Direction.north) && nodeSrc.NeighborNodes[Direction.north] == nodeDest)
                    {
                        activeAnimation = Sprite.Animations["walkNorth"];
                    }
                    else if (nodeSrc.NeighborNodes.ContainsKey(Direction.east) && nodeSrc.NeighborNodes[Direction.east] == nodeDest)
                    {
                        activeAnimation = Sprite.Animations["walkEast"];
                    }
                    else if (nodeSrc.NeighborNodes.ContainsKey(Direction.south) && nodeSrc.NeighborNodes[Direction.south] == nodeDest)
                    {
                        activeAnimation = Sprite.Animations["walkSouth"];
                    }
                    else if (nodeSrc.NeighborNodes.ContainsKey(Direction.west) && nodeSrc.NeighborNodes[Direction.west] == nodeDest)
                    {
                        activeAnimation = Sprite.Animations["walkWest"];
                    }
                }
                
                activeAnimation.AnimationState = AnimationState.Playing;
            }
        }

        private Vector2D directionVector;

        public Character(Sprite sprite) {
            this.Sprite = sprite;
            this.Speed = Constantes.characterSpeed;

            activeAnimation = Sprite.Animations["walkEast"];
            activeAnimation.AnimationState = AnimationState.Playing;
        }

        private void Update() {
            this.Position = this.Position + this.Speed * this.directionVector;
            Sprite.Position = this.Position;

            float length = (this.Position - this.nodeDest.Position).Length;

            if (length < Constantes.deltaDistance) {
                this.nodeDest.CharacterVisit(this);
            }
        }

        public void Draw(float dtime) {
            activeAnimation.Advance(dtime);
            Sprite.Draw();

            Update();
        }
    }
}
