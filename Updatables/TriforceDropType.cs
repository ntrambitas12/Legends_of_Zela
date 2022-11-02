using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class TriforceDropType : IItemType
{
    private IDrop triforce;

    public TriforceDropType(IDrop triforce)
    {
        this.triforce = triforce;
    }

    public void Update(GameTime gameTime)
    {
        if (triforce.ShouldDraw())
        {
            ISprite collidingObject = triforce.collider.isIntersecting(new List<ISprite> { RoomObjectManager.Instance.currentRoom().Link });

            if (collidingObject != null)
            {
                triforce.SetShouldDraw(false);
                // Add to Link's inventory here
            }
        }
    }
}