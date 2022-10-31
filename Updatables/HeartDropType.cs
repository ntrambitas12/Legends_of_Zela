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

    public void Update(GameTime gameTime)
    {
        if (heart.ShouldDraw())
        {
            IConcreteSprite Link = (IConcreteSprite)RoomObjectManager.Instance.currentRoom().Link;
            ISprite collidingObject = heart.collider.isIntersecting(new List<ISprite> { Link });

            if (collidingObject != null)
            {               
                if (Link.health < Link.maxHealth)
                {
                    heart.SetShouldDraw(false);
                    Link.health++;
                }
            }
        }
    }
}