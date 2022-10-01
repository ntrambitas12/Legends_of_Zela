using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DamagedState : ISpriteState
{
    private IConcreteSprite sprite;
    private IDraw drawSprite;

    private SpriteAction prevAction;
    private ISpriteState prevState;


    //naive approach to regulating frame rate. figure better way in the future
    private int counter = 0;

    public DamagedState(ISprite sprite)
    {
        this.sprite = (IConcreteSprite)sprite;
        drawSprite = DrawStaticSprite.GetInstance;
    }

    public void Update()
    {
        if (counter > 22)
        {
            counter = 0;
            sprite.SetSpriteState(prevAction, prevState);

        }
        counter++;
    }

    public void Draw()
    {
        drawSprite.Draw(sprite, Color.Red);
    }

    public void SetPosition(SpriteAction action)
    {
        sprite.SetSpriteAction(action);
    }

    public void SetPreviousState(ISpriteState state)
    {
        prevAction = (SpriteAction)sprite.spritePos;
        prevState = state;
    }
}


