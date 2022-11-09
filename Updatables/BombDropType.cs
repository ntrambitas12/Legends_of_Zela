using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

public class BombDropType : IItemType
{
    IDrop bomb;
    public BombDropType(IDrop bomb)
    {
        this.bomb = bomb;
    }

    public void Update(GameTime gameTime)
    {
        ISprite Link = RoomObjectManager.Instance.currentRoom().Link;
        if (bomb.ShouldDraw())
        {
            ISprite collidingObject = bomb.collider.isIntersecting(new List<ISprite> { Link });

            if (collidingObject != null)
            {
                bomb.SetShouldDraw(false);
                ItemSelectionScreen.AddToInventory(bomb, ArrayIndex.bomb);
                IProjectile Bomb = (IProjectile)SpriteFactory.Instance.CreateBombProjectile(100, Link);
                ((ConcreteSprite)Link).AddProjectile(Bomb, ArrayIndex.bomb);
                ((ConcreteSprite)Link).SetProjectileIndex(ArrayIndex.bomb);
            }
        }
    }
}


