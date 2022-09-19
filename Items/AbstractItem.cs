using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public abstract class AbstractItem : AbstractSprite, IItem
{
    private IDraw drawSprite;
    private IPosition posUpdate;
    public int direction;
    public Vector2 changeCord;
    public ICommand fireProjectile;
    public Boolean shouldDraw;

    public AbstractItem(SpriteBatch spriteBatch, Vector2 position, List<Texture2D>[] textures) : base(spriteBatch, position, textures)
    {
        drawSprite = new DrawSprite();
        posUpdate = new UpdateSpritePos();
        direction = -1;
        changeCord = this.screenCord;
        fireProjectile = null;
        shouldDraw = false;
    }

    public override void Draw()
    {
        if (shouldDraw)
        {
            drawSprite.Draw(this);
        }
    }

    public void SetDirection(int direction)
    {
        this.direction = direction;
    }

    public void SetFireCommand(ICommand fireProjectile)
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

    public void SetPosition(Vector2 pos)
    {
        changeCord = pos;
        this.screenCord = changeCord;
    }
}


