using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MovingState : ISpriteState
{
    private IConcreteSprite sprite;
    private IPosition position;
    private IDraw drawSprite;
    public Boolean isDamaged { get; set; }

    public MovingState(IConcreteSprite sprite)
    {
        this.sprite = sprite;
        position = UpdateSpritePos.GetInstance;
        drawSprite = new DrawSprite();
    }
    public void Draw(GameTime gameTime)
    {
        if (isDamaged)
        {
            drawSprite.Draw(sprite, Color.Red, false, gameTime);
        }
        else
        {
            drawSprite.Draw(sprite, Color.White, true, gameTime);
        }
    }

    public void Update(GameTime gameTime)
    {
        position.Update(sprite);
 
    }

    public void SetPreviousState(ISpriteState state)
    {
        //implement if needed
    }

    public string toString()
    {
        return "MovingState";
    }
}
