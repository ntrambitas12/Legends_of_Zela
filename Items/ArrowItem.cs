using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class ArrowItem : AbstractSprite, IItem
{
    private int count;
    private int pos;
    private IDraw drawSprite = new DrawSprite();
    private IPosition posUpdate = new UpdateSpritePos();
    private int direction;
    private Vector2 changeCord;
    private ICommand fireProjectile;
    private Boolean shouldDraw;

    public ArrowItem(SpriteBatch spriteBatch, Vector2 position, List<Texture2D>[] textures) : base(spriteBatch, position, textures)
    {
        count = 0;
        pos = 0;
        direction = -1;
        changeCord = this.screenCord;
        shouldDraw = false;
    }

    public override void Update()
    {
        switch (direction)
        {
            case 0:
                changeCord.X--;
                break;
            case 1:
                changeCord.X++;
                break;
            case 2:
                changeCord.Y--;
                break;
            case 3:
                changeCord.Y++;
                break;
            default:
                break;
        }
        this.screenCord = changeCord;

        if (shouldDraw)
        {
            fireProjectile.Execute();
        }
    }

    public override void Draw()
    {
        drawSprite.Draw(this);
    }

    public void Shoot(SpriteAction direction, Vector2 sourcePos)
    {
        switch(direction)
        {
            case SpriteAction.stillLeft:
            case SpriteAction.damageLeft:

                break;
            case SpriteAction.stillRight:
            case SpriteAction.damageRight:


                break;
            case SpriteAction.stillUp:
            case SpriteAction.damageUp:

                break;
            case SpriteAction.stillDown:
            case SpriteAction.damageDown:

                break;
            default:
                // Don't allow to shoot if moving or attacking with sword
                break;
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


