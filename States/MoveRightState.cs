using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902Project.States
{
    public class MoveRightState : ISpriteState
    {
        private IConcreteSprite sprite;
        private IPosition position;
        private IDraw drawSprite;

        public MoveRightState(IConcreteSprite sprite)
        {
            this.sprite = sprite;
            position = UpdateSpritePos.GetInstance;
            drawSprite = DrawSprite.GetInstance;
        }

        public void Update()
        {
            position.Update((ISprite)sprite);
        }
        public void Draw()
        {
            drawSprite.Draw((ISprite)sprite, Color.White);
        }
        public void SetPosition(SpriteAction action)
        {
            sprite.SetSpriteAction(SpriteAction.moveRight);
        }
    }
}
