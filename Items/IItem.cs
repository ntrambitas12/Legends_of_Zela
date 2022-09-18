using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public interface IItem : ISprite
{
    public void Shoot(SpriteAction direction, Vector2 sourcePos);
    //public void Add(List<ISprite> sprites);
    //public void Remove(List<ISprite> sprites);
    public void SetDirection(int direction);
    public void SetFireCommand(ICommand fireProjectile);
    public Boolean ShouldDraw();
    public void SetShouldDraw(Boolean condition);
    public void SetPosition(Vector2 pos);
}


