using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902Project.Commands
{
    public class MoveDown : ICommand
    {
        private IConcreteSprite Link;
        public MoveDown(ISprite link)
        {
            this.Link = (IConcreteSprite)link;
        }
        public void Execute()
        {
            
            Link.SetSpriteState(SpriteAction.moveDown, Link.moving);
            Link.Update();
        }
    }
}