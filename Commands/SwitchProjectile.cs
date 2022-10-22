using System;

public class SwitchProjectile : ICommand
{
    private ConcreteSprite Link;
    private int i;

    public SwitchProjectile(ISprite Link)
    {
        this.Link = (ConcreteSprite)Link;
        i = 0;
    }

    public void Execute()
    {
        i = (i + 1) % 3;
        Link.SetProjectileIndex((ArrayIndex)i);
    }
}


