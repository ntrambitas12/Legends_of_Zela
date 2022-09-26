using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class ConcreteItem : AbstractSprite, IItem
{
    private IDraw drawSprite;
    private IPosition posUpdate;
    private int direction;
    private Vector2 changeCord;
    private FireProjectile fireProjectile;
    private Boolean shouldDraw;
    private IProjectileType projectileType;
    private int distance;
    private ISprite owner;

    public ConcreteItem(SpriteBatch spriteBatch, Vector2 position, List<Texture2D>[] textures) : base(spriteBatch, position, textures)
    {
        drawSprite = new DrawSprite();
        posUpdate = new UpdateSpritePos();
        direction = -1;
        changeCord = this.screenCord;
        fireProjectile = null;
        shouldDraw = false;
        projectileType = new NotProjectile();
        distance = 0;
        owner = null;
    }

    public override void Draw()
    {
        if (shouldDraw)
        {
            drawSprite.Draw(this);
        }
    }

    public override void Update()
    {
        projectileType.Update();
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

    public bool ShouldDraw()
    {
        return shouldDraw;
    }

    public void SetShouldDraw(bool condition)
    {
        shouldDraw = condition;
    }

    public Vector2 Position()
    {
        return this.screenCord;
    }

    public void SetPosition(Vector2 pos)
    {
        changeCord = pos;
        this.screenCord = changeCord;
    }

    public IProjectileType ProjectileType()
    {
        return this.projectileType;
    }

    public void SetProjectileType(IProjectileType projectileType)
    {
        this.projectileType = projectileType;
    }

    public int Distance()
    {
        return this.distance;
    }

    public void SetDistance(int distance)
    {
        this.distance = distance;
    }

    public ISprite Owner()
    {
        return this.owner;
    }

    public void SetOwner(ISprite owner)
    {
        this.owner = owner;
    }
}


