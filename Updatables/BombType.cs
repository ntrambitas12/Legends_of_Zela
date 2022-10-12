using System;
using Microsoft.Xna.Framework;

public class BombType : IItemType
{
    private IProjectile projectile;
    private FireProjectile fireProjectile;
    private bool shouldDraw;
    private int counter;
    private int distance;

    public BombType(IProjectile projectile)
    {
        this.projectile = projectile;
    }

    public void Update(GameTime gameTime)
    {
        fireProjectile = projectile.FireCommand();
        shouldDraw = projectile.ShouldDraw();
        counter = fireProjectile.Counter();
        distance = projectile.Distance();

        if (counter == distance - 25)
        {
            projectile.SetSpriteAction(SpriteAction.bombCloud);
        }

        if (shouldDraw)
        {
            fireProjectile.Execute();
        }
    }
}


