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
    public class LinkStill : ICommand
    {
        private IConcreteSprite Link;
        private SpriteAction linkPos;

        public LinkStill(ISprite link)
        {
            Link = (IConcreteSprite)link;
            
        }
        public void Execute()
        {
            int spritePos = Link.spritePos; 
            switch(spritePos)
            {
                case 0:
                    linkPos = SpriteAction.moveLeft;
                    break;
                case 1:
                    linkPos = SpriteAction.moveRight;
                    break;
                case 2:
                    linkPos = SpriteAction.moveUp;
                    break;
                case 3:
                    linkPos = SpriteAction.moveDown;
                    break;          
                    default:
                    linkPos = SpriteAction.moveLeft;
                    break;

            }
            Link.SetSpriteState(linkPos, Link.still);
            Link.Update();
        }
    }
}