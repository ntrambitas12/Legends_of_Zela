using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DeadState : ISpriteState
{
    public void Draw(GameTime gameTime)
    {
        //no need to draw, sprite is not active
    }

    public void SetPreviousState(ISpriteState state)
    {
       // implement if needed
    }

    public void Update(GameTime gameTime)
    {
        //no need to update, sprite is not active
    }
}
