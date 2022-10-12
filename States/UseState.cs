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


    public UseState(ISprite sprite)
    {
        this.sprite = sprite;
        drawSprite = new DrawSprite();
    }

    public void Update(GameTime gameTime)
    {
        //no updated needed; link is stationary when he is using an item
    }

    public void Draw(GameTime gameTime)
    {
        drawSprite.Draw(sprite, Color.White, false, gameTime);

    }
    

    public void SetPreviousState(ISpriteState state)
    {
       //implement if needed
    }
}


