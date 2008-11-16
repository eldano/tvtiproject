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

        public SceneNode NodeDest
        {
            get { return nodeDest; }
            set {
                nodeSrc = nodeDest;
                nodeDest = value;

                directionVector = nodeDest.Position - nodeSrc.Position;
                directionVector.Normalize();

                if (nodeSrc.NeighborNodes[Direction.north] == nodeDest)
                {
                    activeAnimation.AnimationState = AnimationState.Stopped;
                    //Switch to north animation
                    //activeAnimation = Sprite.Animations["walkNorth"];
                    activeAnimation.AnimationState = AnimationState.Playing;
                }
                else if (nodeSrc.NeighborNodes[Direction.east] == nodeDest)
                {
                    //Switch to east animation
                }
                else if (nodeSrc.NeighborNodes[Direction.south] == nodeDest)
                {
                    //Switch to south animation
                }
                else if (nodeSrc.NeighborNodes[Direction.west] == nodeDest)
                {
                    //Switch to west animation
                }

            }
        }

        private Vector2D directionVector;

        public Character(Sprite sprite) {
            this.Sprite = sprite;
        }

        public void Update() {
            this.Position = this.Position + this.Speed * this.directionVector;

        }
    }
}
