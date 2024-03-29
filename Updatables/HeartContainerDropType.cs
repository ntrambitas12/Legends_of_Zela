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

    public static IItemType CreateDrop(IDrop drop)
    {
        return new HeartContainerDropType(drop);
    }

    public void Update(GameTime gameTime)
    {
        if (heartContainer.ShouldDraw())
        {
            IConcreteSprite Link = (IConcreteSprite)RoomObjectManager.Instance.currentRoom().Link;
            ISprite collidingObject = heartContainer.collider.isIntersecting(new List<ISprite> { Link });

            if (collidingObject != null)
            {
                SoundManager.Instance.PlayOnce("LOZ_Get_Heart");
                heartContainer.SetShouldDraw(false);
                RoomObjectManager.Instance.DeleteGameObject((int)RoomObjectTypes.typePickup, heartContainer);
                Link.maxHealth+=2;
                Link.health+=2;
            }
        }
    }
}
