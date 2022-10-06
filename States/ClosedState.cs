using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    internal class ClosedState : ISpriteState
    {

        private IConcreteSprite sprite;
        private IDraw drawSprite;

    public ClosedState(ISprite sprite)
    {
        drawSprite = DrawSprite.GetInstance;
        this.sprite = (IConcreteSprite)sprite;
    }
    //Draw door closed sprite
    public void Draw()
        {
            drawSprite.Draw(sprite, Color.White, true);
        }

        public void SetPosition(SpriteAction action)
        {
            sprite.SetSpriteAction(action);
        }

        public void SetPreviousState(ISpriteState state)
        {
            //implement if needed
        }

        public void Update()
        {
        //add collideable object
        }
    }

