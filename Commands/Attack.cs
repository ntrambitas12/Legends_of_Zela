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
        if (!RoomObject.pauseLink)
        {
            sprite.SetSpriteState((SpriteAction)sprite.spritePos, sprite.attack);
        }
    }
}


