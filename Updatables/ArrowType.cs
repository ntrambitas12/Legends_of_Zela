using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics; 

public class ArrowType : IProjectileType
{
    private IProjectile projectile;
    private int direction;
    private FireProjectile fireProjectile;
    private bool shouldDraw;
    private Vector2 changeCord;

    public ArrowType(IProjectile projectile)
    {
        this.projectile = projectile;
    }

    public void Update(GameTime gameTime)
    {
        direction = projectile.Direction();
        fireProjectile = projectile.FireCommand();
        shouldDraw = projectile.ShouldDraw();
        changeCord = projectile.Position();

        switch (direction)
        {
            case 0:
                changeCord.X -= 4;
                break;
            case 1:
                changeCord.X += 4;
                break;
            case 2:
                changeCord.Y -= 4;
                break;
            case 3:
                changeCord.Y += 4;
                break;
            default:
                break;
        }
        projectile.SetPosition(changeCord);

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
            IRoomObject currRoom = RoomObjectManager.Instance.currentRoom();
            ISprite collidingObject = projectile.collider.isIntersecting(currRoom.ProjectileStopperList);

            if (collidingObject != null)
            {
                fireProjectile.ResetCounter();
            }

            collidingObject = projectile.collider.isIntersecting(new List<ISprite> { currRoom.Link });
            bool check = projectile.Owner() != currRoom.Link;

            if (check && collidingObject != null)
            {
                fireProjectile.ResetCounter();
                currRoom.TakeDamage(collidingObject);
            }

            collidingObject = projectile.collider.isIntersecting(currRoom.EnemyList);
            check = !(currRoom.EnemyList.Contains(projectile.Owner()));
            check = check && !currRoom.DeadEnemyList.Contains(collidingObject);

            if (check && collidingObject != null)
            {
                if (((IConcreteSprite)collidingObject).health == 1)
                {
                    fireProjectile.ResetCounter();
                    currRoom.KillEnemy(collidingObject);
                    DropHandler.Drop(currRoom, collidingObject.screenCord);
                } else
                {
                    ((IConcreteSprite)collidingObject).health--;
                }
            }
        }
    }
}


