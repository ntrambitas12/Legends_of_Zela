using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics; 

public class ArrowType : IItemType
{
    private IProjectile projectile;
    private int direction;
    private ICommand fireProjectile;
    private bool shouldDraw;
    private Vector2 changeCord;

    public ArrowType(IProjectile projectile)
    {
        this.projectile = projectile;
    }

    public void Update(GameTime gameTime)
    {
        direction = projectile.Direction();
        fireProjectile = projectile.FireCommand();
        shouldDraw = projectile.ShouldDraw();
        changeCord = projectile.Position();

        switch (direction)
        {
            case 0:
                changeCord.X -= 4;
                break;
            case 1:
                changeCord.X += 4;
                break;
            case 2:
                changeCord.Y -= 4;
                break;
            case 3:
                changeCord.Y += 4;
                break;
            default:
                break;
        }
        projectile.SetPosition(changeCord);

        if (shouldDraw)
        {
            fireProjectile.Execute();
        }
    }
}


