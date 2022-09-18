using System;

    public class StillState:IItemState
    {
    //might want to use IItem interface
    private ISprite sprite;
    private IDraw drawSprite = new DrawSprite();

        public StillState(ISprite sprite)
        {
        this.sprite = sprite;
        }

    void IItemState.Attack()
    {
        // change state to attack states
        //sprite.Attack();
    }

    void IItemState.Draw()
    {
        sprite.SetSpriteAction(SpriteAction.stillUp);
        drawSprite.Draw(sprite);

    }

    void IItemState.Update()
    {
        // Nothing
    }
}


