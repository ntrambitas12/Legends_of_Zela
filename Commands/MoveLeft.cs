using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902Project.Commands
{
    public class MoveLeft : ICommand
    {
        private IConcreteSprite Link;

        public MoveLeft(ISprite link)
        {
            this.Link = (IConcreteSprite)link;
        }
        public void Execute()
        {
            Link.SetSpriteState(SpriteAction.moveLeft, Link.moving);
            Link.Update();
        }
    }
}