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

        if (counter == distance - 25)
        {
            projectile.SetSpriteAction(SpriteAction.bombCloud);
        }

        if (shouldDraw)
        {
            fireProjectile.Execute();
        }

        //check for collisions and effects
        if (shouldDraw)
        {
            ISprite collidingObject = projectile.collider.isIntersecting(RoomObjectManager.Instance.currentRoom().StaticTileList);

            if (collidingObject != null)
            {
                fireProjectile.ResetCounter();
            }

            //collidingObject = projectile.collider.isIntersecting(new List<ISprite> { RoomObjectManager.Instance.currentRoom().Link });

            //if (collidingObject != null)
            //{
            //    fireProjectile.ResetCounter();
            //    //RoomObjectManager.Instance.TakeDamage(collidingObject);
            //}

            collidingObject = projectile.collider.isIntersecting(RoomObjectManager.Instance.currentRoom().EnemyList);

            if (collidingObject != null)
            {
                fireProjectile.ResetCounter();
                //RoomObjectManager.Instance.TakeDamage(collidingObject);
            }
        }
    }
}


