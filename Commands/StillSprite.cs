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
    public class StillSprite : ICommand
    {
        private IConcreteSprite sprite;
        private SpriteAction spritePos;

        public StillSprite(ISprite sprite)
        {
            this.sprite = (IConcreteSprite)sprite;
            
        }
        public void Execute()
        {

            /* Control which direction the sprite is facing when they are told to stand still */
            int spritePos = sprite.spritePos; 
            switch(spritePos)
            {
                case 0:
                    this.spritePos = SpriteAction.moveLeft;
                    break;
                case 1:
                    this.spritePos = SpriteAction.moveRight;
                    break;
                case 2:
                    this.spritePos = SpriteAction.moveUp;
                    break;
                case 3:
                    this.spritePos = SpriteAction.moveDown;
                    break;          
                    default:
                    //this.spritePos = (SpriteAction)sprite.spritePos;
                    break;

            }

            /* This allows us to retain directional data, but stop the sprite from moving */
                sprite.SetSpriteState(this.spritePos, sprite.still);
        }
    }
}