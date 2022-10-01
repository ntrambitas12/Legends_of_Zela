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

    /* This use command was more or less for demonstration/testing purposes. It was absorbed into UseState.cs */
    public class Use : ICommand
    {
        private IConcreteSprite sprite;
        private SpriteAction spritePos;

        public Use(ISprite sprite)
        {
            this.sprite = (IConcreteSprite)sprite;
        }

        public void Execute()
        {
            int spritePos = sprite.spritePos; 
            switch (spritePos)
            {
                case 0:
                    this.spritePos = SpriteAction.useLeft;
                    break;
                case 1:
                    this.spritePos = SpriteAction.useRight;
                    break;
                case 2:
                    this.spritePos = SpriteAction.useUp;
                    break;
                case 3:
                    this.spritePos = SpriteAction.useDown;
                    break;          
                default:
                    //this.spritePos = (SpriteAction)sprite.spritePos;
                    break;

            }
            sprite.SetSpriteState(this.spritePos, sprite.attack);

        }
    }
}