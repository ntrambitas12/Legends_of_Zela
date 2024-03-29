﻿using System;
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

    public static IItemType CreateDrop(IDrop drop)
    {
        return new BowDropType(drop);
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
                RoomObjectManager.Instance.DeleteGameObject((int)RoomObjectTypes.typePickup, bow);
                ItemSelectionScreen.AddToInventory(bow, ArrayIndex.arrow);

                IProjectile Arrow = (IProjectile)SpriteFactory.Instance.CreateArrowProjectile(999, Link, "Arrow", (int)RoomObjectTypes.typeEnemyProjectile);
                ((ConcreteSprite)Link).AddProjectile(Arrow, ArrayIndex.arrow);
                ((ConcreteSprite)Link).SetProjectileIndex(ArrayIndex.arrow);

            }
        }
    }
}


