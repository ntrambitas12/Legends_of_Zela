﻿using Microsoft.Xna.Framework;
using System;
using static System.Collections.Specialized.BitVector32;

public class StillAnimated : ISpriteState
{
    private ConcreteSprite sprite;
    private IDraw drawSprite;


    public StillAnimated(ConcreteSprite sprite)
    {
        this.sprite = sprite;
        drawSprite = new DrawSprite();
    }


    public void Draw(GameTime gameTime)
    {
        drawSprite.Draw(sprite, Color.White, true, gameTime);

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
        return "StillAnimated";
    }
}