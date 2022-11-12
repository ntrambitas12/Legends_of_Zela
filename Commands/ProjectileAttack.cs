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
        if (!RoomObject.pauseLink)
        {
            sprite.SetSpriteState((SpriteAction)sprite.spritePos, sprite.use);
        }
    }
}


