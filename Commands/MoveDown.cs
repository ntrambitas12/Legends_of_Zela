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
        private ISprite Link;
        private Vector2 currentPos;

        public MoveDown(ISprite link)
        {
            this.Link = link;
            this.currentPos = link.screenCord;
        }
        public void Execute()
        {
            Link.SetSpriteAction(SpriteAction.moveDown);
            currentPos.Y++;
            Link.Update();
        }
    }
}