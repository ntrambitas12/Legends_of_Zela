using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Interface for the Collision Manager.
//The single point where all collisions are updated.
internal interface ICollisionManager
{
    //updates all game objects in current room
    public void Update(GameTime gameTime);

    //add collisions to entity
    public ISprite AddCollisions(ISprite entity, ColliderType collider, Rectangle collisionRect);

    //returns room rectangle
    public Rectangle roomEdge();
}

public enum ColliderType
{
    Normal = 11,
    Keese = 12,
}