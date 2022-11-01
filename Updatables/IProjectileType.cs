using System;
using Microsoft.Xna.Framework;

public interface IProjectileType : IItemType
{
    public void UpdateCollisions(GameTime gameTime);
}


