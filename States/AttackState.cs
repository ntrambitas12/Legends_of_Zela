﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AttackState : ISpriteState
{
    private IConcreteSprite sprite;
    private IDraw drawSprite;
    private SpriteAction prevAction;
    private ISpriteState prevState;
   

    //naive approach to regulating frame rate. figure better way in the future
    private int counter = 0;

    public AttackState(ISprite sprite)
    {
        drawSprite = DrawSprite.GetInstance;
        this.sprite = (IConcreteSprite)sprite;
    }

    public void Update()
    {
        if (counter > 20)
        {
            counter = 0;
            sprite.SetSpriteState(prevAction, prevState);
            
        }
        counter++;
    }

    public void Draw()
    {
        drawSprite.Draw(sprite, Color.White);

    }
    
    public void SetPosition(SpriteAction action)
    {
        sprite.SetSpriteAction(action);
    }

    public void SetPreviousState(ISpriteState state)
    {
        prevAction = (SpriteAction)sprite.spritePos;
        prevState = state;
    }
}

