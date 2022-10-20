using System;

public class ProjectileAttack : ICommand
{
    private IConcreteSprite sprite;

    public ProjectileAttack(ISprite sprite)
    {
        this.sprite = (ConcreteSprite) sprite;
    }

    public void Execute()
    {
        sprite.SetSpriteState((SpriteAction)sprite.spritePos, sprite.use);
    }
}


