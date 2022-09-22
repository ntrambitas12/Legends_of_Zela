using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class FireProjectile : ICommand
{
    private ISprite shooter;
    private IItem projectile;
    private int counter;
    private Vector2 newCord;
    public int distance;

    public FireProjectile(ISprite shooter, IItem projectile)
    {
        this.shooter = shooter;
        this.projectile = projectile;
        counter = 0;
        distance = projectile.Distance();
    }

    public void Execute()
    {
        if (counter == 0)
        {
            projectile.SetSpriteAction((SpriteAction)shooter.spritePos);
            projectile.SetDirection(shooter.spritePos);
            newCord = projectile.screenCord;
            switch (shooter.spritePos)
            {
                // Probably want sprite to hold info about where to start each
                // shot, can use that info here
                case 0: // left
                    newCord.X = shooter.screenCord.X + 20;
                    newCord.Y = shooter.screenCord.Y + 20;
                    break;
                case 1: // right
                    newCord.X = shooter.screenCord.X + 20;
                    newCord.Y = shooter.screenCord.Y + 20;
                    break;
                case 2: // up
                    newCord.X = shooter.screenCord.X + 20;
                    newCord.Y = shooter.screenCord.Y + 20;
                    break;
                case 3: // down
                    newCord.X = shooter.screenCord.X + 20;
                    newCord.Y = shooter.screenCord.Y + 20;
                    break;
                default:
                    break;
            }
            projectile.SetPosition(newCord);
            projectile.SetShouldDraw(true);
        }



        if (counter == distance)
        {
            projectile.SetShouldDraw(false);
            projectile.SetDirection(-1);
            counter = 0;
        }
        else
        {
            counter++;
        }
    }

    public int Counter()
    {
        return counter;
    }
}

