using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BladeTrapBehavior : IAI
{

    private enum CONSTANTS
    {
    }

    //--------------------------------VARIABLES--------------------------------
    //the entity this is for
    public ISprite entity { get; set; }

    private bool pauseEnemies;
    private IRoomObject currRoom;
    private Vector2 corner;

    //--------------------------------INITIALIZER--------------------------------
    //must be passed an entity for 'this' to be attached to, and size of collider 'colliderDimensions'
    public BladeTrapBehavior(ISprite entity)
    {
        this.entity = entity;
        corner = entity.screenCord;
    }

    //--------------------------------METHODS--------------------------------
    public void Update(GameTime gameTime)
    {
        currRoom = RoomObjectManager.Instance.currentRoom();
        IConcreteSprite link = (IConcreteSprite)currRoom.Link;
        this.pauseEnemies = currRoom.IsPauseEnemies();
        if (!pauseEnemies)
        {
            if (Math.Abs(link.screenCord.X - entity.screenCord.X) < 10 && (entity.screenCord.X == 208 + currRoom.BaseCord.X || entity.screenCord.X == 560 + currRoom.BaseCord.X))
            {
                Vector2 cord = entity.screenCord;
                //move up or down
                if (link.screenCord.Y > entity.screenCord.Y)
                {
                    //move down
                    cord.Y += 3;
                } else
                {
                    //move up
                    cord.Y -= 3;
                }
                entity.screenCord = cord;
            } else if (Math.Abs(link.screenCord.Y - entity.screenCord.Y) < 10 && (entity.screenCord.Y == 370 + currRoom.BaseCord.Y || entity.screenCord.Y == 178 + currRoom.BaseCord.Y))
            {
                Vector2 cord = entity.screenCord;
                //move left or right
                if (link.screenCord.X > entity.screenCord.X)
                {
                    //move right
                    cord.X += 3;
                } else
                {
                    //move left
                    cord.X -= 3;
                }
                entity.screenCord = cord;
            } else
            {
                returnToCorner(entity);
            }
            
        }
    }

    private void returnToCorner(ISprite entity)
    {
        Vector2 cord = entity.screenCord;
        if (corner.X == 208 + currRoom.BaseCord.X && corner.Y == 178 + currRoom.BaseCord.Y)
        {
            //move to left up
            if (entity.screenCord.X > 208 + currRoom.BaseCord.X)
            {
                // move left
                cord.X -= 1;
            } else
            {
                // move up
                cord.Y -= 1;
            }
        } else if (corner.X == 560 + currRoom.BaseCord.X && corner.Y == 178 + currRoom.BaseCord.Y)
        {
            //move to right up
            if (entity.screenCord.X < 560 + currRoom.BaseCord.X)
            {
                // move right
                cord.X += 1;
            }
            else
            {
                // move up
                cord.Y -= 1;
            }
        }
        else if (corner.X == 208 + currRoom.BaseCord.X && corner.Y == 370 + currRoom.BaseCord.Y)
        {
            //move to left down
            if (entity.screenCord.X > 208 + currRoom.BaseCord.X)
            {
                // move left
                cord.X -= 1;
            }
            else
            {
                // move down
                cord.Y += 1;
            }
        }
        else
        {
            //move to right down
            if (entity.screenCord.X < 560 + currRoom.BaseCord.X)
            {
                // move right
                cord.X += 1;
            } else
            {
                // move down
                cord.Y += 1;
            }
        }
        //if (entity.screenCord.X == 208 + currRoom.BaseCord.X || entity.screenCord.X == 560 + currRoom.BaseCord.X)
        //{
        //    //move up or down
        //    if (entity.screenCord.Y < currRoom.BaseCord.Y + (370 + 178) / 2)
        //    {
        //        //move up
        //        cord.Y -= 2;
        //    } else
        //    {
        //        //move down
        //        cord.Y += 2;
        //    }
        //} else
        //{
        //    //move left or right
        //    if (entity.screenCord.X < currRoom.BaseCord.X + (208 + 560) / 2)
        //    {
        //        //move left
        //        cord.X -= 2;
        //    } else
        //    {
        //        //move right
        //        cord.X += 2;
        //    }
        //}
        entity.screenCord = cord;
    }

    public void SetProjectile(IProjectile projectile)
    {
        //no projectile
    }
}
