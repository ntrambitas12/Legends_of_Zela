using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Security.AccessControl;

public class Projectile : AbstractItem, IProjectile
{
    private int direction;
    private FireProjectile fireProjectile;
    private int distance;
    private bool shouldCollide;
    private String dropName;
    private String dropDesc;
    private int roomObjectType;

    public Projectile(SpriteBatch spriteBatch, Vector2 position, List<Texture2D>[] textures, String name, int roomObjectType) : base(spriteBatch, position, textures)
    {
        direction = -1;
        fireProjectile = null;
        distance = 0;
        shouldCollide = true;
        dropName = name + "Drop";
        dropDesc = name;
        this.roomObjectType = roomObjectType;
    }

    public int Direction()
    {
        return this.direction;
    }
    public int GetRoomObjectType()
    {
        return roomObjectType;
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

    public bool ShouldCollide()
    {
        return shouldCollide;
    }

    public void SetShouldCollide(bool shouldCollide)
    {
        this.shouldCollide = shouldCollide;
    }

    public string GetDropName()
    {
        return dropName;
    }

    public string GetDropDescription()
    {
        return dropDesc;
    }
}


