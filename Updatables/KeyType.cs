using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class KeyType : IItemType
{
    private IDrop key;

    public KeyType(IDrop key)
    {
        this.key = key;
    }

    public void Update(GameTime gameTime)
    {
        if (key.ShouldDraw())
        {
            ISprite collidingObject = key.collider.isIntersecting(new List<ISprite> { RoomObjectManager.Instance.currentRoom().Link });

            if (collidingObject != null)
            {
                key.SetShouldDraw(false);
                // Add to Link's inventory here
            }
        }
    }
}

