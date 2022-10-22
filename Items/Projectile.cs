using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class Projectile : AbstractItem, IProjectile
{
    private int direction;
    private FireProjectile fireProjectile;
    private int distance;

    public Projectile(SpriteBatch spriteBatch, Vector2 position, List<Texture2D>[] textures) : base(spriteBatch, position, textures)
    {
        direction = -1;
        fireProjectile = null;
        distance = 0;
    }

    public int Direction()
    {
        return this.direction;
    }

    public void SetDirection(int direction)
    {
        this.direction = direction;
    }

    public FireProjectile FireCommand()
    {
        return this.fireProjectile;
    }

    public void SetFireCommand(FireProjectile fireProjectile)
    {
        this.fireProjectile = fireProjectile;
    }

    public int Distance()
    {
        return this.distance;
    }

    public void SetDistance(int distance)
    {
        this.distance = distance;
    }
}


