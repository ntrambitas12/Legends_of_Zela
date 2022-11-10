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
    private float timeElapsed;

    //--------------------------------INITIALIZER--------------------------------
    private CollisionManager()
    {
        timeElapsed = 0;
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

            // updates link projectile collisions
            UpdateLinkProjectile(gameTime);

            // updates enemy projectile collisions
            UpdateEnemyProjectile(gameTime);

            // updates closed door
            UpdateLockedDoors(gameTime);
        }
        timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    //updates Link's collisions
    private void UpdateLink(GameTime gameTime)
    {
        if (currentRoom.Link != null)
        {
            //wall collision and repulsion
            UpdateCollideWithWall(currentRoom.Link, currentRoom, false);
            //contact damage with enemy
            if (timeElapsed > 2 && // something not working here
                (currentRoom.Link.collider.isIntersecting(RoomObjectManager.Instance.currentRoom().EnemyList) != null ||
                currentRoom.Link.collider.isIntersecting(RoomObjectManager.Instance.currentRoom().EnemyProjectileList) != null))
            {
                ((IConcreteSprite)(currentRoom.Link)).TakeDamage();
                timeElapsed = 0;
            }

            //update the moveable tiles
            UpdateMoveableTiles(currentRoom.Link, currentRoom);
        }
    }
    //updates enemies's collisions
    private void UpdateEnemies(GameTime gameTime)
    {
        foreach (IConcreteSprite enemy in currentRoom.EnemyList)
        {
            UpdateCollideWithWall(enemy, currentRoom, true);
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

    // updates closed door collisions
    private void UpdateLockedDoors(GameTime gameTime)
    {
        foreach (ISprite door in currentRoom.LockedDoorsList.Keys)
        {
            IConcreteSprite _door = (IConcreteSprite) door;
            IConcreteSprite colliding = (IConcreteSprite) _door.collider.isIntersecting( new List<ISprite> { currentRoom.Link });

            if (colliding != null && colliding.keys > 0 && timeElapsed > 0.5
                && currentRoom.LockedDoorsList.TryGetValue(door, out bool closed)
                && closed) // colliding is link if not null
            {
                timeElapsed = 0;
                currentRoom.OpenDoor(door);
                colliding.keys--;
            }
        }
    }

    //call so the entity gets repelled by walls
    private void UpdateCollideWithWall(ISprite entity, IRoomObject roomObject, bool enemy)
    {
        entity.collider.ResetCollisionBooleans();
        entity.collider.UpdateCollision(roomObject.StaticTileList);
        entity.collider.UpdateCollision(roomObject.DynamicTileList);
        foreach (IConcreteSprite door in currentRoom.LockedDoorsList.Keys)
        {
            if (currentRoom.LockedDoorsList.TryGetValue(door, out bool closed) && closed)
            {
                entity.collider.UpdateCollision(door);
            }
        }
        foreach (IConcreteSprite door in currentRoom.BombDoorsList.Keys)
        {
            if (currentRoom.BombDoorsList.TryGetValue(door, out bool closed) && closed)
            {
                entity.collider.UpdateCollision(door);
            }
        }
        if (enemy)
        {
            //only run this for enemies
            entity.collider.UpdateCollision(roomObject.MoveableTileList);
        }
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

    //call to update moveable tiles
    private void UpdateMoveableTiles(ISprite entity, IRoomObject roomObject)
    {
        entity.collider.ResetCollisionBooleans();
        entity.collider.UpdateCollision(roomObject.MoveableTileList);
     
        if (entity.collider.isColliding)
        {
            ISprite collidedEntity = entity.collider.collidedEntity;
            if (entity.collider.isCollidingBottom)
            {
                Vector2 position = collidedEntity.screenCord;
                double x = collidedEntity.screenCord.X;
                double y = collidedEntity.screenCord.Y + (int)CONSTANTS.REPULSION;
                collidedEntity.screenCord = new Vector2((int)x, (int)y);
            }
            if (entity.collider.isCollidingTop)
            {
                Vector2 position = collidedEntity.screenCord;
                double x = collidedEntity.screenCord.X;
                double y = collidedEntity.screenCord.Y - (int)CONSTANTS.REPULSION;
                collidedEntity.screenCord = new Vector2((int)x, (int)y);
            }
            if (entity.collider.isCollidingLeft)
            {
                Vector2 position = collidedEntity.screenCord;
                double x = collidedEntity.screenCord.X - (int)CONSTANTS.REPULSION;
                double y = collidedEntity.screenCord.Y;
                collidedEntity.screenCord = new Vector2((int)x, (int)y);
            }
            if (entity.collider.isCollidingRight)
            {
                Vector2 position = collidedEntity.screenCord;
                double x = collidedEntity.screenCord.X + (int)CONSTANTS.REPULSION;
                double y = collidedEntity.screenCord.Y;
                collidedEntity.screenCord = new Vector2((int)x, (int)y);
            }
            collidedEntity.collider.UpdateCollisionPosition();
        } 
    }
}
