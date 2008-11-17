using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GorgonLibrary;
using GorgonLibrary.Graphics;

namespace TVTIProject
{
    public class GoalNode: SceneNode
    {

        public GoalNode(Vector2D position, Sprite sprite) : base(position, sprite) { 
        
        }

        public override void MouseClick(InventoryItem item)
        {
            throw new NotImplementedException();
        }

        public override void CharacterVisit(Character character)
        {
            throw new NotImplementedException();
        }

        public override void Draw(float dtime)
        {
            this.Sprite.Animations[""].Advance(dtime);
            throw new NotImplementedException();
        }
    }
}
