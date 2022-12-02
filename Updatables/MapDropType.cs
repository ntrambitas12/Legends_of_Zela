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

    public static IItemType CreateDrop(IDrop drop)
    {
        return new MapDropType(drop);
    }

    public void Update(GameTime gameTime)
    {
        if (map.ShouldDraw())
        {
            IConcreteSprite link = (IConcreteSprite)RoomObjectManager.Instance.currentRoom().Link;
            ISprite collidingObject = map.collider.isIntersecting(new List<ISprite> { link });

            if (collidingObject != null)
            {
                SoundManager.Instance.PlayOnce("LOZ_Get_Item");
                map.SetShouldDraw(false);
                link.map = true;
            }
        }
    }
}