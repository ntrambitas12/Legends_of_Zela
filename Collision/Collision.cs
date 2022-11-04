using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Collision : ICollision
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

    //collider rect for this
    public Rectangle rect { get; set; }
    private Rectangle colliderDimensions;


    //--------------------------------INITIALIZER--------------------------------
    //must be passed an entity for 'this' to be attached to, and size of collider 'colliderDimensions'
    public Collision(ISprite entity, Rectangle colliderDimensions)
    {
        this.entity = entity;
        this.colliderDimensions = colliderDimensions;
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

        foreach (ISprite collidingEntity in collidibleList)
        {
            Rectangle intersectRect = Rectangle.Intersect(this.rect, ((Collision)collidingEntity.collider).rect);
            //check for initial collision
            if (intersectRect.Height > (int)CONSTANTS.THRESHHOLD && intersectRect.Width > (int)CONSTANTS.THRESHHOLD)
            {
                this.isColliding = true;                                                //collision detected
                if (intersectRect.Height > intersectRect.Width)                         //check whether horizontal or vertical collision
                {
                    //case 1: horizontal collision (intersectRect has higher height)
                    if (this.rect.Left > collidingEntity.collider.rect.Left)            //check for colliding direction (L/R)
                    {
                        //case 1A: collidingEntity is left of this.entity
                        isCollidingLeft = true;
                    }
                    else
                    {
                        //case 1B: collidingEntity is right of this.entity
                        isCollidingRight = true;
                    }
                }
                else
                {
                    //case 2: vertical collision (intersectRect has higher width)
                    if (this.rect.Top > collidingEntity.collider.rect.Top)              //check for colliding direction (U/D)
                    {
                        //case 2A: collidingEntity is above this.entity
                        isCollidingTop = true;
                    }
                    else
                    {
                        //case 2B: collidingEntity is below this.entity
                        isCollidingBottom = true;
                    }
                }
            }
        }
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
}
