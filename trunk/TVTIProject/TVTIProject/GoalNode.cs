using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GorgonLibrary;

namespace TVTIProject
{
    public class GoalNode: SceneNode
    {

        public GoalNode(Vector2D position) : base(position) { 
        
        }

        public override void MouseClick(InventoryItem item)
        {
            throw new NotImplementedException();
        }

        public override void CharacterVisit(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
