using System;
using Microsoft.Xna.Framework;

public class ArrowDropType : IItemType
{
    IDrop arrow;
    public ArrowDropType(IDrop arrow)
    {
        this.arrow = arrow;
    }

    public void Update(GameTime gameTime)
    {
        throw new NotImplementedException();
    }
}


