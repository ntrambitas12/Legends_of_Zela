using CSE3902Project;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902Project.Commands
{
    public class MoveUp : ICommand
    {
        private IConcreteSprite Link;

        public MoveUp(ISprite link)
        {
            this.Link = (IConcreteSprite)link;
            
        }
        public void Execute()
        {
            Link.SetSpriteState(SpriteAction.moveUp, Link.moving);
            Link.Update();
            //Link.SetSpriteState(SpriteAction.moveUp, Link.still);
        }
    }
}