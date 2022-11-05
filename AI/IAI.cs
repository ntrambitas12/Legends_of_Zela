using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//interface for the Collision class
//each entity that needs to check for collisions must store a separate instance of the Collision object
public interface IAI
{
    //the entity this is for
    public ISprite entity { get; set; }

    //updates ai module
    public void Update(GameTime gameTime);

}

public enum AIType
{
    RandomMove = 11,
    AlwaysRandomMove = 12,
}