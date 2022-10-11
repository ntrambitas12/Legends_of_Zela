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
    private float timeElapsed;
    private int counter = 0;


   

    public DamagedState(ISprite sprite)
    {
        this.sprite = (IConcreteSprite)sprite;
        drawSprite = DrawSprite.GetInstance;
        timeElapsed = 0;
    }

    public void Update(GameTime gameTime)
    {

        timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
        counter++;

        if (timeElapsed > 2)
        {
            timeElapsed = 0;
            sprite.SetSpriteState(prevAction, prevState);
            counter = 0;

        }
    }

    public void Draw(GameTime gameTime)
    {
        drawSprite.Draw(sprite, Color.Red, false, gameTime);
    }


    public void SetPreviousState(ISpriteState state)
    {
        if (counter < 2)
        {
            prevAction = (SpriteAction)sprite.spritePos;
            prevState = state;
        }
    }
}


