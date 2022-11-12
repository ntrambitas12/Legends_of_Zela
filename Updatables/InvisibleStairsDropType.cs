using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class InvisibleStairDropType : IItemType
{
    private IDrop stairs;

    public InvisibleStairDropType(IDrop stairs)
    {
        this.stairs = stairs;
    }

    public void Update(GameTime gameTime)
    {
        ISprite collidingObject = stairs.collider.isIntersecting(new List<ISprite> { RoomObjectManager.Instance.currentRoom().Link });

        if (collidingObject != null)
        {
            RoomObjectManager.Instance.setRoom(25, false);
            IRoomObject currRoom = RoomObjectManager.Instance.currentRoom();
            currRoom.Link.screenCord = new Vector2(360 + currRoom.BaseCord.X, 275 + currRoom.BaseCord.Y);
        }

    }
}