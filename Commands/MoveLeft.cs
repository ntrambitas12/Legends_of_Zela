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
        private IConcreteSprite sprite;
        public MoveLeft(ISprite sprite)
        {
            this.sprite = (IConcreteSprite)sprite;
        }
        public void Execute()
        {
            sprite.SetSpriteState(SpriteAction.moveLeft, sprite.moving);
        }
    }
}