using Microsoft.Xna.Framework;
using System;

    public class StillState : ISpriteState
    {
    private ConcreteSprite sprite;
    private IDraw drawSprite;

        public StillState(ConcreteSprite sprite)
        {
            this.sprite = sprite;
            drawSprite = DrawSprite.GetInstance;
        }


    public void Draw()
    {
        drawSprite.Draw(sprite, Color.White, false);

    }

    public void Update()
    {
        //No update code needed for still state

    }
    public void SetPosition(SpriteAction action)
    {
        sprite.SetSpriteAction(action);
    }

    public void SetPreviousState(ISpriteState state)
    {
        //implement if needed
    }
}


