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
    //returns room rectangle
    public Rectangle roomEdge();
}
