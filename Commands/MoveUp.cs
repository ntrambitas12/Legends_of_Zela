using CSE3902Project;
using CSE3902Project.States;
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
        private Vector2 currentPos;

        public MoveUp(IConcreteSprite link)
        {
            this.Link = link;
            this.currentPos = link.screenCord;
        }
        public void Execute()
        {
            Link.SetSpriteState(SpriteAction.moveUp, this.Link.MoveUpState);
            currentPos.Y--;
            Link.Update();
        }
    }
}