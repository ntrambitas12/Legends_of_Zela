using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics; 

public class ArrowType : IItemType
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
        if (shouldDraw)
        {
            ISprite collidingObject = projectile.collider.isIntersecting(RoomObjectManager.Instance.currentRoom().StaticTileList);

            if (collidingObject != null)
            {
                fireProjectile.ResetCounter();
            }

            collidingObject = projectile.collider.isIntersecting(new List<ISprite> { RoomObjectManager.Instance.currentRoom().Link });
            bool check = projectile.Owner() != RoomObjectManager.Instance.currentRoom().Link;

            if (check && collidingObject != null)
            {
                fireProjectile.ResetCounter();
                //RoomObjectManager.Instance.TakeDamage(collidingObject);
            }

            collidingObject = projectile.collider.isIntersecting(RoomObjectManager.Instance.currentRoom().EnemyList);
            check = !(RoomObjectManager.Instance.currentRoom().EnemyList.Contains(projectile.Owner()));

            if (check && collidingObject != null)
            {
                fireProjectile.ResetCounter();
                //RoomObjectManager.Instance.TakeDamage(collidingObject);
            }
        }
    }
}


