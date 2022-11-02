using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

public class SwordType : IProjectileType
{
    private IProjectile sword;
    private FireProjectile fireProjectile;
    private bool shouldDraw;

    public SwordType(IProjectile sword)
    {
        this.sword = sword;
    }

    public void Update(GameTime gameTime)
    {
        fireProjectile = sword.FireCommand();
        shouldDraw = sword.ShouldDraw();

        if (shouldDraw)
        {
            fireProjectile.Execute();
        }

        //check for collisions and effects
        //UpdateCollisions(gameTime);
    }


    //check for collisions and effects
    public void UpdateCollisions(GameTime gameTime)
    {
        if (shouldDraw)
        {
            ISprite collidingObject = sword.collider.isIntersecting(new List<ISprite> { RoomObjectManager.Instance.currentRoom().Link });
            bool check = sword.Owner() != RoomObjectManager.Instance.currentRoom().Link;

            if (check && collidingObject != null)
            {
                RoomObjectManager.Instance.currentRoom().TakeDamage(collidingObject);
            }

            collidingObject = sword.collider.isIntersecting(RoomObjectManager.Instance.currentRoom().EnemyList);
            check = !(RoomObjectManager.Instance.currentRoom().EnemyList.Contains(sword.Owner()));

            if (check && collidingObject != null)
            {
                if (RoomObjectManager.Instance.currentRoom().EnemyToProjectile.TryGetValue(collidingObject, out ISprite enemyProjectile))
                {
                    RoomObjectManager.Instance.currentRoom().DeleteGameObject((int)RoomObjectTypes.typeEnemyProjectile, enemyProjectile);
                }
                RoomObjectManager.Instance.currentRoom().DeleteGameObject((int)RoomObjectTypes.typeEnemy, collidingObject);
            }
        }
    }
}


