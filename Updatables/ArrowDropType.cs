using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class ArrowDropType : IItemType
{
    private IDrop arrow;

    public ArrowDropType(IDrop arrow)
    {
        this.arrow = arrow;
    }

    public void Update(GameTime gameTime)
    {
        if (arrow.ShouldDraw())
        {
            ISprite collidingObject = arrow.collider.isIntersecting(new List<ISprite> { RoomObjectManager.Instance.currentRoom().Link });

            if (collidingObject != null)
            {
                arrow.SetShouldDraw(false);
                // Add to Link's inventory here
            }
        }
    }
}