using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public interface IItem : ISprite
{
    public void SetDirection(int direction);
    public void SetFireCommand(ICommand fireProjectile);
    public bool ShouldDraw();
    public void SetShouldDraw(Boolean condition);
    public void SetPosition(Vector2 pos);
}


