﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class HeartContainerDropType : IItemType
{
    private IDrop heartContainer;

    public HeartContainerDropType(IDrop heartContainer)
    {
        this.heartContainer = heartContainer;
    }

    public void Update(GameTime gameTime)
    {
        if (heartContainer.ShouldDraw())
        {
            IConcreteSprite Link = (IConcreteSprite)RoomObjectManager.Instance.currentRoom().Link;
            ISprite collidingObject = heartContainer.collider.isIntersecting(new List<ISprite> { Link });

            if (collidingObject != null)
            {
                heartContainer.SetShouldDraw(false);
                Link.maxHealth++;
                Link.health++;
            }
        }
    }
}