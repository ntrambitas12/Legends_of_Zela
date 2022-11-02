using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class UseState : ISpriteState
{
    private IConcreteSprite sprite;
    private IDraw drawSprite;
    private SpriteAction prevAction;
    private ISpriteState prevState;
    private float timeElapsed;
    private int counter = 0;


    public UseState(ISprite sprite)
    {
        drawSprite = new DrawSprite();
        this.sprite = (IConcreteSprite)sprite;
        timeElapsed = 0;
    }

    public void Update(GameTime gameTime)
    {
        timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
        counter++;

        if (counter == 2)
        {
            switch (sprite.spritePos % 4)
            {
                case 0: //L
                    sprite.SetSpriteAction(SpriteAction.useLeft);
                    break;
                case 1: //R
                    sprite.SetSpriteAction(SpriteAction.useRight);
                    break;
                case 2: //U
                    sprite.SetSpriteAction(SpriteAction.useUp);
                    break;
                case 3: //D
                    sprite.SetSpriteAction(SpriteAction.useDown);
                    break;
                default:
                    break;
            }
            
            sprite.ProjectileAttack();
            SoundManager.Instance.PlayOnce("LOZ_Arrow_Boomerang");

        }

        if (timeElapsed > .2)
        {
            timeElapsed = 0;
            sprite.SetSpriteState(prevAction, prevState);
            counter = 0;

        }


    }

    public void Draw(GameTime gameTime)
    {
        drawSprite.Draw(sprite, Color.White, true, gameTime);
    }

    public void SetPreviousState(ISpriteState state)
    {
        if (counter < 2)
        {
            prevAction = (SpriteAction)sprite.spritePos;
            prevState = state;
        }
    }
    public string toString()
    {
        return "UseState";
    }
}




//using Microsoft.Xna.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//public class UseState : ISpriteState
//{
//    private ISprite sprite;
//    private IDraw drawSprite;
//    private SpriteAction prevAction;
//    private ISpriteState prevState;

//    public UseState(ISprite sprite)
//    {
//        this.sprite = sprite;
//        drawSprite = new DrawSprite();
//    }

//    public void Update(GameTime gameTime)
//    {
//        ((ConcreteSprite)sprite).ProjectileAttack();
//        ((ConcreteSprite)sprite).SetSpriteState(prevAction, prevState);
//    }

//    public void Draw(GameTime gameTime)
//    {
//        drawSprite.Draw(sprite, Color.White, false, gameTime);

//    }


//    public void SetPreviousState(ISpriteState state)
//    {
//        prevAction = (SpriteAction)sprite.spritePos;
//        prevState = state;
//    }
//}



