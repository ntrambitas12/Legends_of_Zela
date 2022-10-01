using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class FireProjectile : ICommand
{
    private IItem projectile;
    private IConcreteSprite shooter;
    public int counter;
    private Vector2 newCord;
    public int distance;

    public FireProjectile(IItem projectile)
    {
        this.projectile = projectile;
        shooter = (IConcreteSprite)projectile.Owner();
        counter = -1;
        newCord = new Vector2(0,0);
        distance = projectile.Distance();
    }

    public void Execute()
    {
        if (counter == 0)
        {
            shooter = (IConcreteSprite)projectile.Owner();
            projectile.SetSpriteAction((SpriteAction)shooter.spritePos);
            projectile.SetDirection(shooter.spritePos);
            newCord = projectile.screenCord;

            shooter.SetSpriteState((SpriteAction)shooter.spritePos, shooter.attack);


            switch (shooter.spritePos)
            {
                // Probably want sprite to hold info about where to start each
                // shot, can use that info here
                case 0: // left
                    newCord.X = shooter.screenCord.X + 5;
                    newCord.Y = shooter.screenCord.Y + 5;
                    break;
                case 1: // right
                    newCord.X = shooter.screenCord.X + 13;
                    newCord.Y = shooter.screenCord.Y + 3;
                    break;
                case 2: // up
                    newCord.X = shooter.screenCord.X + 5;
                    newCord.Y = shooter.screenCord.Y;
                    break;
                case 3: // down
                    newCord.X = shooter.screenCord.X + 5;
                    newCord.Y = shooter.screenCord.Y + 11;
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

