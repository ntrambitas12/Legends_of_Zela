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
            IConcreteSprite link = (IConcreteSprite) RoomObjectManager.Instance.currentRoom().Link;
            ISprite collidingObject = compass.collider.isIntersecting(new List<ISprite> { link });

            if (collidingObject != null)
            {
                SoundManager.Instance.PlayOnce("LOZ_Get_Item");
                compass.SetShouldDraw(false);
                link.compass = true;
            }
        }
    }
}