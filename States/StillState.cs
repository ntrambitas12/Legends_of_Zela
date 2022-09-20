using System;

    public class StillState:ISpriteState
    {
    private ConcreteSprite sprite;
    private IDraw drawSprite;

        public StillState(ConcreteSprite sprite)
        {
        this.sprite = sprite;
        drawSprite = new DrawSprite();
        }


    public void Draw()
    {
        drawSprite.Draw(sprite);

    }

    public void Update()
    {
        sprite.SetSpriteAction(SpriteAction.stillRight);

    }
    public void SetPosition(SpriteAction action)
    {
        sprite.SetSpriteAction(action);
    }

}


