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
    private DeadState dead;
    private float timeElapsed;
    private int counter = 0;
    public int health = 0;


   

    public DamagedState(ISprite sprite)
    {
        this.sprite = (IConcreteSprite)sprite;
        drawSprite = new DrawSprite();
        dead = new DeadState(sprite);
        timeElapsed = 0;
    }

    public void Update(GameTime gameTime)
    {
        health = this.sprite.health;
        timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
        counter++;

        if (health <= 0)
        {
            sprite.SetSpriteState(SpriteAction.damage, dead);
            SoundManager.Instance.PauseSounds();
            SoundManager.Instance.PlayOnce("LOZ_Link_Die");//this will play for enemies too

        }

        else if (timeElapsed > 2)
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
    public string toString()
    {
        return "DamagedState";
    }
}


