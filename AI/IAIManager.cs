using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Interface for the AI Manager.
//The single point where all AI are updated.
internal interface IAIManager
{
    //updates all game objects in current room
    public void Update(GameTime gameTime);
}
