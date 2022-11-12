using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CollisionKeese : ICollision
{

    private enum CONSTANTS
    {
        //overlap allowance
        THRESHHOLD = 5,
    }

    //--------------------------------VARIABLES--------------------------------
    //the entity this is for
    public ISprite entity { get; set; }

    //gets set by UpdateCollision() method. true if this rectangle is intersecting with rectangles of entity(s) inside list
    public Boolean isColliding { get; set; }

    //same as isColliding, but specific for each direction
    //used to disallow movement when colliding with obstable
    public Boolean isCollidingTop { get; set; }
    public Boolean isCollidingBottom { get; set; }
    public Boolean isCollidingLeft { get; set; }
    public Boolean isCollidingRight { get; set; }
    
    //set the object that the entity collided with
    public ISprite collidedEntity { get; set; }
    //collider rect for this
    public Rectangle rect { get; set; }
    private Rectangle colliderDimensions;
    private Rectangle roomEdgeRect;


    //--------------------------------INITIALIZER--------------------------------
    //must be passed an entity for 'this' to be attached to, and size of collider 'colliderDimensions'
    public CollisionKeese(ISprite entity, Rectangle colliderDimensions)
    {
        this.entity = entity;
        this.colliderDimensions = colliderDimensions;
        this.roomEdgeRect = CollisionManager.Instance.roomEdge();
    }

    //--------------------------------METHODS--------------------------------

    public void ResetCollisionBooleans()
    {
        //reset isColliding booleans
        isColliding = false;
        isCollidingTop = false;
        isCollidingBottom = false;
        isCollidingLeft = false;
        isCollidingRight = false;
        collidedEntity = null;
    }

    //updates collider rect's position
    public void UpdateCollisionPosition()
    {
        this.rect = new Rectangle((int)entity.screenCord.X, (int)entity.screenCord.Y, colliderDimensions.Width, colliderDimensions.Height);
    }
    //sets the various isColliding booleans against collidibleList
    public void UpdateCollision(List<ISprite> collidibleList)
    {

        //update collider position
        this.rect = new Rectangle((int)entity.screenCord.X, (int)entity.screenCord.Y, colliderDimensions.Width, colliderDimensions.Height);

        //do nothing, phases through blocks
    }

    //overload for single element
    public void UpdateCollision(ISprite collidable)
    {
        List<ISprite> collidableList = new List<ISprite> { collidable };
        UpdateCollision(collidableList);
    }

    //returns the object that this.rect has intersected with. returns null if not intersecting with anything in list
    public ISprite isIntersecting(ICollection<ISprite> collidibleList)
    {

        //update collider position
        this.rect = new Rectangle((int)entity.screenCord.X, (int)entity.screenCord.Y, colliderDimensions.Width, colliderDimensions.Height);

        foreach (ISprite collidingEntity in collidibleList)                                 //iterate through list
        {
            if (this.rect.Intersects(collidingEntity.collider.rect))                    //check for collision with entities in list
            {
                return collidingEntity;                                                 //return collidingEntity if intersecting
            }
        }
        return null;
    }

    //updates booleans against room edges
    public void UpdateCollisionRoomEdge()
    {
        Vector2 roomOffset = RoomObjectManager.Instance.currentRoom().BaseCord;

        if (this.rect.Top < roomEdgeRect.Top + roomOffset.Y)
        {
            this.isColliding = true;
            this.isCollidingTop = true;
        }
        if (this.rect.Bottom > roomEdgeRect.Bottom + roomOffset.Y)
        {
            this.isColliding = true;
            this.isCollidingBottom = true;
        }
        if (this.rect.Left < roomEdgeRect.Left + roomOffset.X)
        {
            this.isColliding = true;
            this.isCollidingLeft = true;
        }
        if (this.rect.Right > roomEdgeRect.Right + roomOffset.X)
        {
            this.isColliding = true;
            this.isCollidingRight = true;
        }
    }
}
