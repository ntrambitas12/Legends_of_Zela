using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class MapDropType : IItemType
{
    private IDrop map;

    public MapDropType(IDrop map)
    {
        this.map = map;
    }

    public void Update(GameTime gameTime)
    {
        if (map.ShouldDraw())
        {
            ISprite collidingObject = map.collider.isIntersecting(new List<ISprite> { RoomObjectManager.Instance.currentRoom().Link });

            if (collidingObject != null)
            {
                SoundManager.Instance.PlayOnce("LOZ_Get_Item");
                map.SetShouldDraw(false);
                // Add to Link's inventory here
            }
        }
    }
}