using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UseState : ISpriteState
{
    private ISprite sprite;
    private IDraw drawSprite;
    private SpriteAction prevAction;
    private ISpriteState prevState;

    public UseState(ISprite sprite)
    {
        this.sprite = sprite;
        drawSprite = new DrawSprite();
    }

    public void Update(GameTime gameTime)
    {
        ((ConcreteSprite)sprite).ProjectileAttack();
        ((ConcreteSprite)sprite).SetSpriteState(prevAction, prevState);
    }

    public void Draw(GameTime gameTime)
    {
        drawSprite.Draw(sprite, Color.White, false, gameTime);

    }
    

    public void SetPreviousState(ISpriteState state)
    {
        prevAction = (SpriteAction)sprite.spritePos;
        prevState = state;
    }
}


