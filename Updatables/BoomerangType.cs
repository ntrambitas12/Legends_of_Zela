using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class BoomerangType : IItemType
{
    private IProjectile projectile;
    private int direction;
    private FireProjectile fireProjectile;
    private bool shouldDraw;
    private Vector2 changeCord;
    private int counter;
    private int distance;
    private int speed;
    private Vector2 shooterCord;
    private Vector2 directionBack;

    public BoomerangType(IProjectile projectile)
    {
        this.projectile = projectile;
    }

    public void Update(GameTime gameTime)
    {
        direction = projectile.Direction();
        fireProjectile = projectile.FireCommand();
        shouldDraw = projectile.ShouldDraw();
        changeCord = projectile.Position();
        counter = fireProjectile.Counter();
        distance = projectile.Distance();
        speed = 5;

        if (counter >= distance / 3)
        {
            speed = 3;
            shooterCord = projectile.Owner().screenCord;
            directionBack = shooterCord - changeCord;
            directionBack.Normalize();

            changeCord += 3 * directionBack;
        }
        else
        {
            switch (direction)
            {
                case 0:
                    changeCord.X -= speed;
                    break;
                case 1:
                    changeCord.X += speed;
                    break;
                case 2:
                    changeCord.Y -= speed;
                    break;
                case 3:
                    changeCord.Y += speed;
                    break;
                default:
                    break;
            }
        }
        projectile.SetPosition(changeCord);
        
        if (shouldDraw)
        {
            fireProjectile.Execute();
        }

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
            //    //RoomObject.TakeDamage(collidingObject);
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