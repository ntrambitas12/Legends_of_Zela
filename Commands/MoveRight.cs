using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902Project.Commands
{
    public class MoveRight : ICommand
    {
        private IConcreteSprite sprite;
        public MoveRight(ISprite sprite)
        {
            this.sprite = (IConcreteSprite)sprite;
        }
        public void Execute()
        {
            if (!RoomObject.pauseLink)
            {
                sprite.SetSpriteState(SpriteAction.moveRight, sprite.moving);
            }
        }
    }
}