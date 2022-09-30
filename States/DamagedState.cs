﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DamagedState : ISpriteState
{
    private ISprite sprite;
    private IDraw drawSprite;

    public DamagedState(ISprite sprite)
    {
        this.sprite = sprite;
        drawSprite = DrawStaticSprite.GetInstance;
    }

    public void Update()
    {
    }

    public void Draw()
    {
        drawSprite.Draw(sprite, Color.Red);
    }

    public void SetPosition(SpriteAction action)
    {
        sprite.SetSpriteAction(action);
    }
}


