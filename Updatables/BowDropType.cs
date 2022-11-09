using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

public class BowDropType : IItemType
{
    IDrop bow;

    public BowDropType(IDrop bow)
    {
        this.bow = bow;
    }

    public void Update(GameTime gameTime)
    {
        ISprite Link = RoomObjectManager.Instance.currentRoom().Link;
        if (bow.ShouldDraw())
        {
            ISprite collidingObject = bow.collider.isIntersecting(new List<ISprite> { Link });

            if (collidingObject != null)
            {
                SoundManager.Instance.PlayOnce("LOZ_Get_Item");
                bow.SetShouldDraw(false);
                IProjectile Arrow = (IProjectile)SpriteFactory.Instance.CreateArrowProjectile(999, Link);
                ((ConcreteSprite)Link).AddProjectile(Arrow, ArrayIndex.arrow);
            }
        }
    }
}


