using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class StairDropType : IItemType
{
    private IDrop stairs;

    public StairDropType(IDrop stairs)
    {
        this.stairs = stairs;
    }

    public static IItemType CreateDrop(IDrop drop)
    {
        return new StairDropType(drop);
    }

    public void Update(GameTime gameTime)
    {
        ISprite collidingObject = stairs.collider.isIntersecting(new List<ISprite> { RoomObjectManager.Instance.currentRoom().Link });

        if (collidingObject != null)
        {
            SoundManager.Instance.PlayOnce("LOZ_Stairs");
            RoomObjectManager.Instance.setRoom(27, true);
            RoomObjectManager.Instance.currentRoom().Link.screenCord = RoomObjectManager.Instance.currentRoom().BaseCord + new Vector2(240, 200);
        }
        
    }
}
