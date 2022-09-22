using System;
using Microsoft.Xna.Framework;

public class BombType : IProjectileType
{
    private IItem projectile;
    private FireProjectile fireProjectile;
    private bool shouldDraw;
    private int counter;
    private int distance;

    public BombType(IItem projectile)
    {
        this.projectile = projectile;
    }

    public void Update()
    {
        fireProjectile = projectile.FireCommand();
        shouldDraw = projectile.ShouldDraw();
        counter = fireProjectile.Counter();
        distance = projectile.Distance();

        if (counter == distance / 4)
        {
            // Animate the bomb
        }

        if (shouldDraw)
        {
            fireProjectile.Execute();
        }
    }
}


