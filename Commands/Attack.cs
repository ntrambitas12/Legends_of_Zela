using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902Project.Commands
{
    public class Attack : ICommand
    {
        private IConcreteSprite sprite;
        private SpriteAction spritePos;

        public Attack(ISprite link)
        {
            this.sprite = (IConcreteSprite)link;
        }

        public void Execute()
        {
            int spritePos = sprite.spritePos;
            switch (spritePos)
            {
                case 0:
                    this.spritePos = SpriteAction.attackLeft;
                    break;
                case 1:
                    this.spritePos = SpriteAction.attackRight;
                    break;
                case 2:
                    this.spritePos = SpriteAction.attackUp;
                    break;
                case 3:
                    this.spritePos = SpriteAction.attackDown;
                    break;
                default:
                    this.spritePos = SpriteAction.attackDown;
                    break;

            }
            sprite.SetSpriteState(this.spritePos, sprite.still);
        }
    }
}