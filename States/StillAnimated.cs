using Microsoft.Xna.Framework;
using System;
using static System.Collections.Specialized.BitVector32;

public class StillAnimated : ISpriteState
{
    private ConcreteSprite sprite;
    private IDraw drawSprite;

    public StillAnimated(ConcreteSprite sprite)
    {
        this.sprite = sprite;
        drawSprite = DrawSprite.GetInstance;
    }


    public void Draw()
    {
        drawSprite.Draw(sprite, Color.White, true);

    }

    public void Update()
    {
        //No update code needed for still state


    }

    public void SetPreviousState(ISpriteState state)
    {
        //implement if needed
    }
}