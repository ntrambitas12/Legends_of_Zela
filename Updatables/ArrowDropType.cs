using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;

public class ArrowDropType : IItemType
{
    private IDrop arrow;

    public ArrowDropType(IDrop arrow)
    {
        this.arrow = arrow;
    }

    public static IItemType CreateDrop(IDrop drop)
    {
        return new ArrowDropType(drop);
    }
    public void Update(GameTime gameTime)
    {
        if (arrow.ShouldDraw())
        {
            ISprite collidingObject = arrow.collider.isIntersecting(new List<ISprite> { RoomObjectManager.Instance.currentRoom().Link });

            if (collidingObject != null)
            {
                //Add pickup sound
                SoundManager.Instance.PlayOnce("LOZ_Get_Item");
                arrow.SetShouldDraw(false);
                // Add to Link's inventory here
            }
        }
    }
}