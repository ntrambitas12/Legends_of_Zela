using System;

public class Attack : ICommand
{
    private IConcreteSprite sprite;

    public Attack(ISprite sprite)
    {
        this.sprite = (ConcreteSprite)sprite;
    }

    public void Execute()
    {
        sprite.SetSpriteState((SpriteAction)sprite.spritePos, sprite.attack);
    }
}


