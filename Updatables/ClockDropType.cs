﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class ClockDropType : IItemType
{
    private IDrop clock;

    public ClockDropType(IDrop clock)
    {
        this.clock = clock;
    }

    public void Update(GameTime gameTime)
    {
        if (clock.ShouldDraw())
        {
            IRoomObject currentRoom = RoomObjectManager.Instance.currentRoom();
            ISprite collidingObject = clock.collider.isIntersecting(new List<ISprite> {currentRoom.Link });

            if (collidingObject != null)
            {
                SoundManager.Instance.PlayOnce("LOZ_Get_Item");
                clock.SetShouldDraw(false);
                currentRoom.PauseEnemies(false);
            }
        }
    }
}

