using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class FireballType : IProjectileType
{
    private IProjectile projectile;
    private int direction;
    private FireProjectile fireProjectile;
    private bool shouldDraw;
    private Vector2 changeCord;

    public FireballType(IProjectile projectile)
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
           // SoundManager.Instance.PlayOnce("LOZ_Sword_Slash"); fireball sound?
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
            ISprite collidingObject = projectile.collider.isIntersecting(RoomObjectManager.Instance.currentRoom().ProjectileStopperList);

            if (collidingObject != null)
            {
                fireProjectile.ResetCounter();
            }

            collidingObject = projectile.collider.isIntersecting(new List<ISprite> { RoomObjectManager.Instance.currentRoom().Link });
            bool check = projectile.Owner() != RoomObjectManager.Instance.currentRoom().Link;

            if (check && collidingObject != null)
            {
                fireProjectile.ResetCounter();
                RoomObjectManager.Instance.currentRoom().TakeDamage(collidingObject);
            }

            collidingObject = projectile.collider.isIntersecting(RoomObjectManager.Instance.currentRoom().EnemyList);
            check = !(RoomObjectManager.Instance.currentRoom().EnemyList.Contains(projectile.Owner()));

            if (check && collidingObject != null)
            {
                fireProjectile.ResetCounter();
                if (RoomObjectManager.Instance.currentRoom().EnemyToProjectile.TryGetValue(collidingObject, out ISprite enemyProjectile))
                {
                    RoomObjectManager.Instance.currentRoom().DeleteGameObject((int)RoomObjectTypes.typeEnemyProjectile, enemyProjectile);
                }
                RoomObjectManager.Instance.currentRoom().DeleteGameObject((int)RoomObjectTypes.typeEnemy, collidingObject);
            }
        }
    }
}




