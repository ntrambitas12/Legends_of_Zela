using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class BoomerangType : IProjectileType
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
    private bool goingBack;
    private float timeElapsed;

    public BoomerangType(IProjectile projectile)
    {
        this.projectile = projectile;
        goingBack = false;
        timeElapsed = 0;
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

        if (goingBack || counter >= distance / 30)
        {
            speed = 3;
            shooterCord = projectile.Owner().screenCord;
            directionBack = shooterCord - changeCord;
            directionBack.Normalize();

            changeCord += 3 * directionBack;

            goingBack = true;
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
        timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
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
                goingBack = true;
            }

            collidingObject = projectile.collider.isIntersecting(new List<ISprite> { currRoom.Link });

            if (collidingObject != null)
            {
                if (projectile.Owner() != currRoom.Link)
                {
                    goingBack = true;
                    currRoom.TakeDamage(collidingObject);
                }
                else
                {
                    if (goingBack) fireProjectile.ResetCounter();
                    goingBack = false;

                }
            }

            collidingObject = projectile.collider.isIntersecting(currRoom.EnemyList);

            if (collidingObject != null && projectile.ShouldCollide())
            {
                bool check = !currRoom.DeadEnemyList.Contains(collidingObject);
                if (check && !(currRoom.EnemyList.Contains(projectile.Owner())) && timeElapsed > .1)
                {
                    ((IConcreteSprite)collidingObject).health--;
                    projectile.SetShouldCollide(false);
                    goingBack = true;
                    if (((IConcreteSprite)collidingObject).health == 0)
                    {
                        currRoom.KillEnemy(collidingObject);
                        DropHandler.Drop(currRoom, collidingObject.screenCord);
                    }
                }
                else
                {
                    if (goingBack) fireProjectile.ResetCounter();
                    goingBack = false;
                }
            }
        }
    }
}