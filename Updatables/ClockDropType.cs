using System;
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
            ISprite collidingObject = clock.collider.isIntersecting(new List<ISprite> { RoomObjectManager.Instance.currentRoom().Link });

            if (collidingObject != null)
            {
                clock.SetShouldDraw(false);
                // Add to Link's inventory here
            }
        }
    }
}

