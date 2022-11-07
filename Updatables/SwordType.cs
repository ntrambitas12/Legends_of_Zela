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
            IRoomObject currRoom = RoomObjectManager.Instance.currentRoom();
            ISprite collidingObject = sword.collider.isIntersecting(new List<ISprite> { currRoom.Link });
            bool check = sword.Owner() != currRoom.Link;

            if (check && collidingObject != null)
            {
                currRoom.TakeDamage(collidingObject);
            }

            collidingObject = sword.collider.isIntersecting(currRoom.EnemyList);
            check = !(currRoom.EnemyList.Contains(sword.Owner()));

            if (check && collidingObject != null)
            {
                if (currRoom.EnemyToProjectile.TryGetValue(collidingObject, out ISprite enemyProjectile))
                {
                    currRoom.DeleteGameObject((int)RoomObjectTypes.typeEnemyProjectile, enemyProjectile);
                }
                currRoom.DeleteGameObject((int)RoomObjectTypes.typeEnemy, collidingObject);
                DropHandler.Drop(currRoom, collidingObject.screenCord);
            }
        }
    }
}


