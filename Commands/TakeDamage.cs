using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902Project.Commands
{
    public class TakeDamage : ICommand
    {
        private IConcreteSprite sprite;
        private SpriteAction spritePos;

        public TakeDamage(ISprite sprite)
        {
            this.sprite = (IConcreteSprite)sprite;
        }

        public void Execute()
        {
            int spritePos = sprite.spritePos;
            switch (spritePos)
            {
                case 0:
                    this.spritePos = SpriteAction.damageLeft;
                    break;
                case 1:
                    this.spritePos = SpriteAction.damageRight;
                    break;
                case 2:
                    this.spritePos = SpriteAction.damageUp;
                    break;
                case 3:
                    this.spritePos = SpriteAction.damageDown;
                    break;
                default:
                    this.spritePos = SpriteAction.damageDown;
                    break;

            }
            sprite.SetSpriteState(this.spritePos, sprite.damaged);
        }
    }
}