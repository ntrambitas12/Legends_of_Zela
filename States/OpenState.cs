using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    internal class OpenState : ISpriteState
    {

        private IConcreteSprite sprite;
        private IDraw drawSprite;
    public OpenState(ISprite sprite)
    {
        drawSprite = new DrawSprite();
        this.sprite = (IConcreteSprite)sprite;
    }
    //Draw door open sprite
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
    
        // need collidable stuff
        }

    public string toString()
    {
        return "OpenState";
    }
}

