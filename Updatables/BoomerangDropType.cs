using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

public class BoomerangDropType : IItemType
{
    IDrop boomerang;
    public BoomerangDropType(IDrop boomerang)
    {
        this.boomerang = boomerang;
    }

    public static IItemType CreateDrop(IDrop drop)
    {
        return new BoomerangDropType(drop);
    }

    public void Update(GameTime gameTime)
    {
        ISprite Link = RoomObjectManager.Instance.currentRoom().Link;
        if (boomerang.ShouldDraw())
        {
            ISprite collidingObject = boomerang.collider.isIntersecting(new List<ISprite> { Link });

            if (collidingObject != null)
            {
                SoundManager.Instance.PlayOnce("LOZ_Get_Item");
                boomerang.SetShouldDraw(false);
                ItemSelectionScreen.AddToInventory(boomerang, ArrayIndex.boomerang);

                IProjectile Boomerang = (IProjectile)SpriteFactory.Instance.CreateBoomerangProjectile(1000, Link, "Boomerang");
                ((ConcreteSprite)Link).AddProjectile(Boomerang, ArrayIndex.boomerang);
                ((ConcreteSprite)Link).SetProjectileIndex(ArrayIndex.boomerang);

            }
        }
    }
}


