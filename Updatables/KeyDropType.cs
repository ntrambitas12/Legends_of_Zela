using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class KeyDropType : IItemType
{
    private IDrop key;

    public KeyDropType(IDrop key)
    {
        this.key = key;
    }

    public static IItemType CreateDrop(IDrop drop)
    {
        return new KeyDropType(drop);
    }

    public void Update(GameTime gameTime)
    {
        if (key.ShouldDraw())
        {
            IConcreteSprite Link = (IConcreteSprite) RoomObjectManager.Instance.currentRoom().Link;
            ISprite collidingObject = key.collider.isIntersecting(new List<ISprite> { Link });

            if (collidingObject != null)
            {
                SoundManager.Instance.PlayOnce("LOZ_Get_Item");
                key.SetShouldDraw(false);
                RoomObjectManager.Instance.DeleteGameObject((int)RoomObjectTypes.typePickup, key);
                Link.keys++;
            }
        }
    }
}

