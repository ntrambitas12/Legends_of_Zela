using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public sealed class CollisionManager : ICollisionManager
{
    private enum CONSTANTS
    {
        //how much walls repel entities
        REPULSION = 2,
    }
    //--------------------------------VARIABLES--------------------------------
    private static CollisionManager instance = new CollisionManager();
    private IRoomObject currentRoom;

    //--------------------------------INITIALIZER--------------------------------
    private CollisionManager()
    {
    }

    public static CollisionManager Instance { get { return instance; } }

    //--------------------------------METHODS--------------------------------
    
    /* called by Update in Game1
     * updates collision of game objects inside current room */
    public void Update(GameTime gameTime)
    {
        currentRoom = RoomObjectManager.Instance.currentRoom();
        if (currentRoom != null)
        {
            //update Link collisions
            UpdateLink(gameTime);

            //update enemy collisions
            UpdateEnemies(gameTime);

            // TODO: updates link projectile collisions
            UpdateLinkProjectile(gameTime);

            // TODO: updates enemy projectile collisions
            UpdateEnemyProjectile(gameTime);
        }
    }

    //updates Link's collisions
    private void UpdateLink(GameTime gameTime)
    {
        if (currentRoom.Link != null)
        {
            //wall collision and repulsion
            UpdateCollideWithWall(currentRoom.Link, currentRoom);
            //contact damage with enemy
            if (currentRoom.Link.collider.isIntersecting(RoomObjectManager.Instance.currentRoom().EnemyList) != null ||
                currentRoom.Link.collider.isIntersecting(RoomObjectManager.Instance.currentRoom().EnemyProjectileList) != null)
            {
                ((IConcreteSprite)(currentRoom.Link)).TakeDamage();
            }
        }
    }
    //updates enemies's collisions
    private void UpdateEnemies(GameTime gameTime)
    {
        foreach (IConcreteSprite enemy in currentRoom.EnemyList)
        {
            UpdateCollideWithWall(enemy, currentRoom);
        }
    }
    // updates link projectile collisions
    private void UpdateLinkProjectile(GameTime gameTime)
    {
        foreach (IProjectile projectile in ((IConcreteSprite) currentRoom.Link).projectiles)
        {
            if (projectile != null) ((IProjectileType)projectile.ItemType()).UpdateCollisions(gameTime);
        }
    }
    // updates enemy projectile collisions
    private void UpdateEnemyProjectile(GameTime gameTime)
    {
        foreach (IProjectile projectile in currentRoom.EnemyProjectileList)
        {
            if (projectile != null) ((IProjectileType)projectile.ItemType()).UpdateCollisions(gameTime);
        }
    }

    //call so the entity gets repelled by walls
    private void UpdateCollideWithWall(ISprite entity, IRoomObject roomObject)
    {
        entity.collider.ResetCollisionBooleans();
        entity.collider.UpdateCollision(roomObject.StaticTileList);
        entity.collider.UpdateCollision(roomObject.DynamicTileList);
        if (entity.collider.isColliding)
        {
            if (entity.collider.isCollidingBottom)
            {
                Vector2 position = entity.screenCord;
                double x = entity.screenCord.X;
                double y = entity.screenCord.Y - (int)CONSTANTS.REPULSION;
                entity.screenCord = new Vector2((int)x, (int)y);
            }
            if (entity.collider.isCollidingTop)
            {
                Vector2 position = entity.screenCord;
                double x = entity.screenCord.X;
                double y = entity.screenCord.Y + (int)CONSTANTS.REPULSION;
                entity.screenCord = new Vector2((int)x, (int)y);
            }
            if (entity.collider.isCollidingLeft)
            {
                Vector2 position = entity.screenCord;
                double x = entity.screenCord.X + (int)CONSTANTS.REPULSION;
                double y = entity.screenCord.Y;
                entity.screenCord = new Vector2((int)x, (int)y);
            }
            if (entity.collider.isCollidingRight)
            {
                Vector2 position = entity.screenCord;
                double x = entity.screenCord.X - (int)CONSTANTS.REPULSION;
                double y = entity.screenCord.Y;
                entity.screenCord = new Vector2((int)x, (int)y);
            }
        }
    }
}
