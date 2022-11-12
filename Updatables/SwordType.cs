using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

public class SwordType : IProjectileType
{
    private IProjectile sword;
    private FireProjectile fireProjectile;
    private bool shouldDraw;
    private float timeElapsed;

    public SwordType(IProjectile sword)
    {
        this.sword = sword;
        timeElapsed = 0;
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
        timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
    }


    //check for collisions and effects
    public void UpdateCollisions(GameTime gameTime)
    {
        if (shouldDraw && sword.ShouldCollide())
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
            check = check && !currRoom.DeadEnemyList.Contains(collidingObject);

            if (check && collidingObject != null && timeElapsed > .1)
            {
                //if (currRoom.EnemyToProjectile.TryGetValue(collidingObject, out ISprite enemyProjectile))
                //{
                //    currRoom.DeleteGameObject((int)RoomObjectTypes.typeEnemyProjectile, enemyProjectile);
                //}
                ((IConcreteSprite)collidingObject).health--;
                sword.SetShouldCollide(false);
                if (((IConcreteSprite)collidingObject).health == 0)
                {
                    currRoom.KillEnemy(collidingObject);
                    DropHandler.Drop(currRoom, collidingObject.screenCord);
                }
                timeElapsed = 0;
            }
        }
    }
}


