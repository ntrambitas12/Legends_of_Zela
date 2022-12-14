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

    public static IItemType CreateDrop(IDrop drop)
    {
        return new BombDropType(drop);
    }

    public void Update(GameTime gameTime)
    {
        ISprite Link = RoomObjectManager.Instance.currentRoom().Link;
        if (bomb.ShouldDraw())
        {
            ISprite collidingObject = bomb.collider.isIntersecting(new List<ISprite> { Link });

            if (collidingObject != null)
            {
                SoundManager.Instance.PlayOnce("LOZ_Get_Item");
                bomb.SetShouldDraw(false);
                RoomObjectManager.Instance.DeleteGameObject((int)RoomObjectTypes.typePickup, bomb);
                ItemSelectionScreen.AddToInventory(bomb, ArrayIndex.bomb);
                IProjectile Bomb = (IProjectile)SpriteFactory.Instance.CreateBombProjectile(100, Link, "Bomb", (int)RoomObjectTypes.typeEnemyProjectile);
                ((ConcreteSprite)Link).AddProjectile(Bomb, ArrayIndex.bomb);
                ((ConcreteSprite)Link).SetProjectileIndex(ArrayIndex.bomb);
                ((ConcreteSprite)Link).bombs += 4;
            }
        }
    }
}


