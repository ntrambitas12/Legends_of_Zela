using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class FireProjectile : ICommand
{
    private ISprite shooter;
    private IItem projectile;
    private List<IItem> items;
    private int counter;
    private bool isMoving;
    private List<SpriteAction> actions;
    private SpriteAction action;
    private Vector2 newCord;

    public FireProjectile(ISprite shooter, IItem projectile, List<IItem> items)
    {
        this.shooter = shooter;
        this.projectile = projectile;
        this.items = items;
        counter = 0;
        isMoving = false;
    }

    public void Execute()
    {

        if (counter == 0)
        {
            projectile.SetSpriteAction((SpriteAction)shooter.spritePos);
            projectile.SetDirection(shooter.spritePos);
            newCord = projectile.screenCord;
            newCord.X = shooter.screenCord.X + 20;
            newCord.Y = shooter.screenCord.Y + 20;
            //projectile.screenCord = newCord;
            projectile.SetPosition(newCord);
            projectile.SetShouldDraw(true);
            //items.Add(projectile);
        }



        if (counter == 50)
        {
            projectile.SetShouldDraw(false);
            counter = 0;
        }
        else
        {
            counter++;
        }
    }
}

