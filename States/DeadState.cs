using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DeadState : ISpriteState
{
    public void Draw()
    {
        //no need to draw, sprite is not active
    }

    public void SetPosition(SpriteAction action)
    {
        //no need to set position, sprite is inactive
    }

    public void Update()
    {
        //no need to update, sprite is not active
    }
}
