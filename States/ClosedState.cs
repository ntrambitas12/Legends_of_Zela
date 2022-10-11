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
        drawSprite = new DrawSprite();
        this.sprite = (IConcreteSprite)sprite;
    }
    //Draw door closed sprite
    public void Draw(GameTime gameTime)
        {
            drawSprite.Draw(sprite, Color.White, true, gameTime);
        }

        public void SetPreviousState(ISpriteState state)
        {
            //implement if needed
        }

        public void Update(GameTime gameTime)
        {
        //add collideable object
        }
    }

