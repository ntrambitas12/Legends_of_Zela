﻿using Microsoft.Xna.Framework;
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
        private IConcreteSprite sprite;
        public MoveDown(ISprite sprite)
        {
            this.sprite = (IConcreteSprite)sprite;
        }
        public void Execute()
        {
            if (!RoomObject.pauseLink)
            {
                sprite.SetSpriteState(SpriteAction.moveDown, sprite.moving);
            }
        }
    }
}