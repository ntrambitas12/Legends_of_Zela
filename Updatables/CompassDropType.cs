using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class CompassDropType : IItemType
{
    private IDrop compass;

    public CompassDropType(IDrop compass)
    {
        this.compass = compass;
    }

    public void Update(GameTime gameTime)
    {
        if (compass.ShouldDraw())
        {
            ISprite collidingObject = compass.collider.isIntersecting(new List<ISprite> { RoomObjectManager.Instance.currentRoom().Link });

            if (collidingObject != null)
            {
                compass.SetShouldDraw(false);
                // Add to Link's inventory here
            }
        }
    }
}