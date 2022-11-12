using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class FireProjectile : ICommand
{
    private IProjectile projectile;
    private IConcreteSprite shooter;
    public int counter;
    private Vector2 newCord;
    public int distance;

    public FireProjectile(IProjectile projectile)
    {
        this.projectile = projectile;
        shooter = (IConcreteSprite)projectile.Owner();
        counter = 0;
        newCord = new Vector2(0,0);
        distance = projectile.Distance();
    }

    public void Execute()
    {
        if (counter == 0 && !RoomObject.pauseLink)
        {
            shooter = (IConcreteSprite)projectile.Owner();
            projectile.SetSpriteAction((SpriteAction)(shooter.spritePos % 4));
            projectile.SetDirection((shooter.spritePos % 4));
            newCord = projectile.screenCord;
            projectile.SetShouldCollide(true);

            switch ((shooter.spritePos % 4))
            {
                /* Controls which direction the projectile moves in */
                case 0: // left
                    newCord.X = shooter.screenCord.X - 23;
                    newCord.Y = shooter.screenCord.Y + 13;
                    break;
                case 1: // right
                    newCord.X = shooter.screenCord.X + 23;
                    newCord.Y = shooter.screenCord.Y + 13;
                    break;
                case 2: // up
                    newCord.X = shooter.screenCord.X + 5;
                    newCord.Y = shooter.screenCord.Y - 28;
                    break;
                case 3: // down
                    newCord.X = shooter.screenCord.X + 15;
                    newCord.Y = shooter.screenCord.Y + 26;
                    break;
                default:
                    break;
            }
            projectile.SetPosition(newCord);
            projectile.SetShouldDraw(true);
        }

        if (counter == distance)
        {
            ResetCounter();
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

    public void ResetCounter()
    {
        projectile.SetShouldDraw(false);
        projectile.SetDirection(-1);
        counter = 0;
    }
}

