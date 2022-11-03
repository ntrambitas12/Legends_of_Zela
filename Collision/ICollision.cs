using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//interface for the Collision class
//each entity that needs to check for collisions must store a separate instance of the Collision object
public interface ICollision
{
    //the entity this is for
    //reads entity screencoord to set collision rectangle position
    //reads entity width/height to set rectangle dimensions
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

    //collider rectangle, used internally
    public Rectangle rect { get; set; }

    //updates collider rect's position
    public void UpdateCollisionPosition();

    //resets the various isColliding booleans against collidibleList
    public void ResetCollisionBooleans();

    //sets the various isColliding booleans against collidibleList
    //e.g. Link and enemies call UpdateCollision(Game.gameObjects.CollidibleList.get()) to set isColliding against all collidibles
    public void UpdateCollision(List<ISprite> collidibleList);

    //returns the object that this.rect has intersected with. returns null if not intersecting with anything in list
    //does NOT require UpdateCollision() to be called
    //a light-weight method for projectiles and items that do not need complex logic for movement
    public ISprite isIntersecting(List<ISprite> collidibleList);

}