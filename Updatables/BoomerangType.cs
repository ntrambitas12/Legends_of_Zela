using System;
using Microsoft.Xna.Framework;

public class BoomerangType : IItemType
{
    private IProjectile projectile;
    private int direction;
    private FireProjectile fireProjectile;
    private bool shouldDraw;
    private Vector2 changeCord;
    private int counter;
    private int distance;
    private int speed;

    public BoomerangType(IProjectile projectile)
    {
        this.projectile = projectile;
    }

    public void Update(GameTime gameTime)
    {
        direction = projectile.Direction();
        fireProjectile = projectile.FireCommand();
        shouldDraw = projectile.ShouldDraw();
        changeCord = projectile.Position();
        counter = fireProjectile.Counter();
        distance = projectile.Distance();
        speed = 5;

        if (counter == distance / 3)
        {
            switch (direction)
            {
                case 0: // left to right
                    projectile.SetDirection(1);
                    break;
                case 1: // right to left
                    projectile.SetDirection(0);
                    break;
                case 2: // up to down
                    projectile.SetDirection(3);
                    break;
                case 3: // down to up
                    projectile.SetDirection(2);
                    break;
                default:
                    break;
            }
        }

        if (counter >= distance / 3) speed = 3;

        direction = projectile.Direction();
        switch (direction)
        {
            case 0:
                changeCord.X -= speed;
                break;
            case 1:
                changeCord.X += speed;
                break;
            case 2:
                changeCord.Y -= speed;
                break;
            case 3:
                changeCord.Y += speed;
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