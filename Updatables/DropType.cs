using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

public class DropType : IItemType
{
    IDrop drop;

    public DropType(IDrop drop)
    {
        //this.drop = drop;
    }

    public void Update(GameTime gameTime)
    {
        //ISprite collidingObject = drop.collider.isIntersecting(new List<ISprite> { RoomObjectManager.Instance.currentRoom().Link });

        //if (collidingObject != null)
        //{
        //    drop.SetShouldDraw(false);
        //}
    }
}


