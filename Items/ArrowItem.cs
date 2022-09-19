using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class ArrowItem : AbstractItem
{
    public ArrowItem(SpriteBatch spriteBatch, Vector2 position, List<Texture2D>[] textures) : base(spriteBatch, position, textures)
    {
    }

    public override void Update() 
    {
        switch (direction) // This determines the path of the projectile when fired
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
        screenCord = changeCord;

        if (shouldDraw)
        {
            fireProjectile.Execute();
        }
    }
}


