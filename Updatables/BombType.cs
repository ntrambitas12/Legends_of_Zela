using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class BombType : IItemType
{
    private IProjectile projectile;
    private FireProjectile fireProjectile;
    private bool shouldDraw;
    private int counter;
    private int distance;

    public BombType(IProjectile projectile)
    {
        this.projectile = projectile;
    }

    public void Update(GameTime gameTime)
    {
        fireProjectile = projectile.FireCommand();
        shouldDraw = projectile.ShouldDraw();
        counter = fireProjectile.Counter();
        distance = projectile.Distance();

        if (counter >= distance - 20)
        {
            projectile.SetSpriteAction(SpriteAction.bombCloud);

            //check for collisions and effects
            if (shouldDraw)
            {
                ISprite collidingObject = projectile.collider.isIntersecting(RoomObjectManager.Instance.currentRoom().ProjectileStopperList);

                //if (collidingObject != null)
                //{
                //    fireProjectile.ResetCounter();
                //}

                collidingObject = projectile.collider.isIntersecting(new List<ISprite> { RoomObjectManager.Instance.currentRoom().Link });
                bool check = projectile.Owner() != RoomObjectManager.Instance.currentRoom().Link;

                if (check && collidingObject != null)
                {
                    //fireProjectile.ResetCounter();
                    RoomObjectManager.Instance.currentRoom().TakeDamage(collidingObject);
                }

                collidingObject = projectile.collider.isIntersecting(RoomObjectManager.Instance.currentRoom().EnemyList);
                check = !(RoomObjectManager.Instance.currentRoom().EnemyList.Contains(projectile.Owner()));

                if (check && collidingObject != null)
                {
                    //fireProjectile.ResetCounter();
                    if (RoomObjectManager.Instance.currentRoom().EnemyToProjectile.TryGetValue(collidingObject, out ISprite enemyProjectile))
                    {
                        RoomObjectManager.Instance.currentRoom().DeleteGameObject((int)RoomObjectTypes.typeEnemyProjectile, enemyProjectile);
                    }
                    RoomObjectManager.Instance.currentRoom().DeleteGameObject((int)RoomObjectTypes.typeEnemy, collidingObject);
                }
            }
        }

        if (shouldDraw)
        {
            fireProjectile.Execute();
        }
    }
}


