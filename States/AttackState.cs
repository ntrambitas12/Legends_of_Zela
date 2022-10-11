using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AttackState : ISpriteState
{
    private IConcreteSprite sprite;
    private IDraw drawSprite;
    private SpriteAction prevAction;
    private ISpriteState prevState;
    private float timeElapsed;


    public AttackState(ISprite sprite)
    {
        drawSprite = DrawSprite.GetInstance;
        this.sprite = (IConcreteSprite)sprite;
        timeElapsed = 0;
    }

    public void Update(GameTime gameTime)
    {

        timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;


        if (timeElapsed > .2)
        {
            timeElapsed = 0;
            sprite.SetSpriteState(prevAction, prevState);

        }
        

    }

    public void Draw(GameTime gameTime)
    {
        drawSprite.Draw(sprite, Color.White, true, gameTime);
    }
    
    public void SetPreviousState(ISpriteState state)
    {
            prevAction = (SpriteAction)sprite.spritePos;
            prevState = state;
       
    }
}


