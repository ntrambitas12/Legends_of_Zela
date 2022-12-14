using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public sealed class CollisionManager : ICollisionManager
{
    public enum CONSTANTS
    {
        //how much walls repel entities
        REPULSION = 2,

        LEFT_BOUNDARY = 208,
        RIGHT_BOUNDARY = 592,
        UPPER_BOUNDARY = 178,
        LOWER_BOUNDARY = 402,
        MOVEABLE_BLOCK = 31,
    }
    //--------------------------------VARIABLES--------------------------------
    private static CollisionManager instance = new CollisionManager();
    private IRoomObject currentRoom;
    private float timeElapsed;
    private Rectangle roomEdgeRect;

    //--------------------------------INITIALIZER--------------------------------
    private CollisionManager()
    {
        timeElapsed = 0;
        roomEdgeRect = new Rectangle((int)CONSTANTS.LEFT_BOUNDARY, (int)CONSTANTS.UPPER_BOUNDARY,
            (int)CONSTANTS.RIGHT_BOUNDARY - (int)CONSTANTS.LEFT_BOUNDARY, (int)CONSTANTS.LOWER_BOUNDARY - (int)CONSTANTS.UPPER_BOUNDARY);
    }

    public static CollisionManager Instance { get { return instance; } }

    //--------------------------------METHODS--------------------------------

    //returns room rectangle
    public Rectangle roomEdge()
    {
        return roomEdgeRect;
    }

    /* called by Update in RoomObjectManager
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

    //add collisions to entity
    public ISprite AddCollisions(ISprite entity, ColliderType collider, Rectangle collisionRect)
    {
        ICollision collisionObject;
        switch (collider)
        {
            case ColliderType.Normal:
                collisionObject = new Collision(entity, collisionRect);
                break;
            case ColliderType.Keese:
                collisionObject = new CollisionKeese(entity, collisionRect);
                break;
            //case ColliderType.Wallmaster:
            //    collisionObject = new CollisionWallmaster(entity, collisionRect);
            //    break;
            default:
                collisionObject = null;
                break;
        }
        entity.collider = collisionObject;
        entity.collider.UpdateCollisionPosition();
        return entity;
    }

    //updates Link's collisions
    private void UpdateLink(GameTime gameTime)
    {
        if (currentRoom.Link != null)
        {
            //wall collision and repulsion
            UpdateCollideWithWall(currentRoom.Link, currentRoom, false);
            //contact damage with enemy
            List<ISprite> enemyList = new List<ISprite>();
            List<ISprite> projectileList = new List<ISprite>();
            foreach (ISprite enemy in currentRoom.EnemyList)
            {
                if (!(currentRoom.DeadEnemyList.Contains(enemy)))
                {
                    enemyList.Add(enemy);
                    if (currentRoom.EnemyToProjectile.TryGetValue(enemy, out ISprite projectile))
                    {
                        projectileList.Add(projectile);
                    }
                }
            }
            IConcreteSprite collidingEnemy = (IConcreteSprite)currentRoom.Link.collider.isIntersecting(enemyList);
            IProjectile collidingProjectile = (IProjectile) currentRoom.Link.collider.isIntersecting(projectileList);
          
            
            if (collidingEnemy != null && !currentRoom.DeadEnemyList.Contains(collidingEnemy) && timeElapsed > 2)
            {
                if (RoomObjectManager.Instance.currentRoomID() == 18 && collidingEnemy != null)
                {
                    RoomObjectManager.Instance.setRoom(1, true);
                    currentRoom = RoomObjectManager.Instance.currentRoom();
                    currentRoom.Link.screenCord = new Vector2(currentRoom.BaseCord.X + 380, currentRoom.BaseCord.Y + 275);
                }
                else
                {
                    ((IConcreteSprite)(currentRoom.Link)).TakeDamage();
                }
                timeElapsed = 0;
            }
            else if (collidingProjectile != null && !currentRoom.DeadEnemyList.Contains(collidingProjectile.Owner()) && timeElapsed > 2)
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
        //update collider booleans against other objects
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
            entity.collider.UpdateCollisionRoomEdge();
        }

        //shift backwards depending on collider booleans
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
           
            //set the original screen cord once
            if (entity.orgScreenCord.X == 0 && entity.orgScreenCord.Y == 0)
            {
                entity.orgScreenCord = entity.screenCord;
            }

            if (Math.Abs(entity.screenCord.X - entity.orgScreenCord.X) < (int)CONSTANTS.MOVEABLE_BLOCK && Math.Abs(entity.screenCord.Y - entity.orgScreenCord.Y) < (int)CONSTANTS.MOVEABLE_BLOCK)
            {
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
            else
            {
               roomObject.MoveableTileList.Remove(collidedEntity);
               roomObject.StaticTileList.Add(collidedEntity);
            }
        } 
    }
}
