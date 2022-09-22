using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public interface IItem : ISprite
{
    public int Direction();
    public void SetDirection(int direction);
    public FireProjectile FireCommand();
    public void SetFireCommand(FireProjectile fireProjectile);
    public bool ShouldDraw();
    public void SetShouldDraw(Boolean condition);
    public Vector2 Position();
    public void SetPosition(Vector2 pos);
    public IProjectileType ProjectileType();
    public void SetProjectileType(IProjectileType projectileType);
    public int Distance();
    public void SetDistance(int distance);
}
