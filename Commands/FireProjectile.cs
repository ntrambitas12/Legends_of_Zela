using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class FireProjectile : ICommand
{
    private ISprite shooter;
    private IItem projectile;
    private int counter;
    private Vector2 newCord;

    public FireProjectile(ISprite shooter, IItem projectile)
    {
        this.shooter = shooter;
        this.projectile = projectile;
        counter = 0;
    }

    public void Execute()
    {
        if (counter == 0)
        {
            projectile.SetSpriteAction((SpriteAction)shooter.spritePos);
            projectile.SetDirection(shooter.spritePos);
            newCord = projectile.screenCord;
            newCord.X = shooter.screenCord.X + 20; // Probably want sprite to hold info about where to start each shot
            newCord.Y = shooter.screenCord.Y + 20; // can use that info here
            projectile.SetPosition(newCord);
            projectile.SetShouldDraw(true);
        }
        
        if (counter == 50) // change this to change distance of shot
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
}

