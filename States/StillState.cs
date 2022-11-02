using Microsoft.Xna.Framework;
using System;

    public class StillState : ISpriteState
    {
    private ConcreteSprite sprite;
    private IDraw drawSprite;

        public StillState(ConcreteSprite sprite)
        {
            this.sprite = sprite;
            drawSprite = new DrawSprite();
        }


    public void Draw(GameTime gameTime) 
    {
        drawSprite.Draw(sprite, Color.White, false, gameTime);

    }

    public void Update(GameTime gameTime)
    {

        //No update code needed for still state

    }

    public void SetPreviousState(ISpriteState state)
    {
        //implement if needed
    }
    public string toString()
    {
        return "StillState";
    }
}


