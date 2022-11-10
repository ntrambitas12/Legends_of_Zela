using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

public class SwordDropType : IItemType
{
    IDrop sword;
    public SwordDropType(IDrop sword)
    {
        this.sword = sword;
    }

    public void Update(GameTime gameTime)
    {
        ISprite Link = RoomObjectManager.Instance.currentRoom().Link;
        if (sword.ShouldDraw())
        {
            ISprite collidingObject = sword.collider.isIntersecting(new List<ISprite> { Link });

            if (collidingObject != null)
            {
                SoundManager.Instance.PlayOnce("LOZ_Get_Item");
                sword.SetShouldDraw(false);
                IProjectile Sword = (IProjectile)SpriteFactory.Instance.CreateSwordProjectile(12, Link);
                ((ConcreteSprite)Link).AddProjectile(Sword, ArrayIndex.sword);
            }
        }
    }
}
