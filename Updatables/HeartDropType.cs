using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class HeartDropType : IItemType
{
    private IDrop heart;

    public HeartDropType(IDrop heart)
    {
        this.heart = heart;
    }

    public static IItemType CreateDrop(IDrop drop)
    {
        return new HeartDropType(drop);
    }

    public void Update(GameTime gameTime)
    {
        if (heart.ShouldDraw())
        {
            IConcreteSprite Link = (IConcreteSprite)RoomObjectManager.Instance.currentRoom().Link;
            ISprite collidingObject = heart.collider.isIntersecting(new List<ISprite> { Link });

            if (collidingObject != null)
            {
                SoundManager.Instance.PlayOnce("LOZ_Get_Heart");
                heart.SetShouldDraw(false);
                RoomObjectManager.Instance.DeleteGameObject((int)RoomObjectTypes.typePickup, heart);
                if (Link.health < Link.maxHealth)
                {
                    
                    Link.health++;
                }
            }
        }
    }
}