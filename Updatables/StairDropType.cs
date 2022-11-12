﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class StairDropType : IItemType
{
    private IDrop stairs;

    public StairDropType(IDrop stairs)
    {
        this.stairs = stairs;
    }

    public void Update(GameTime gameTime)
    {
        ISprite collidingObject = stairs.collider.isIntersecting(new List<ISprite> { RoomObjectManager.Instance.currentRoom().Link });

        if (collidingObject != null)
        {
            RoomObjectManager.Instance.setRoom(27, true);
            RoomObjectManager.Instance.currentRoom().Link.screenCord = new Vector2(240, 200);
        }
        
    }
}