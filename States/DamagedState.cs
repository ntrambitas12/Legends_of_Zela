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


    //naive approach to controlling how long to keep in damaged state
    private int counter = 0;

    public DamagedState(ISprite sprite)
    {
        this.sprite = (IConcreteSprite)sprite;
        drawSprite = DrawSprite.GetInstance;
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
        drawSprite.Draw(sprite, Color.Red, false);
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


