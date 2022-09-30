﻿using Microsoft.Xna.Framework;
using System;

    public class StillState : ISpriteState
    {
    private ConcreteSprite sprite;
    private IDraw drawSprite;

        public StillState(ConcreteSprite sprite)
        {
            this.sprite = sprite;
            drawSprite = DrawStaticSprite.GetInstance;
        }


    public void Draw()
    {
        drawSprite.Draw(sprite, Color.White);

    }

    public void Update()
    {
        //No update code needed for still state

    }
    public void SetPosition(SpriteAction action)
    {
        sprite.SetSpriteAction(action);
    }

}


