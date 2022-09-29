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

    public MovingState(IConcreteSprite sprite)
    {
        this.sprite = sprite;
        position = UpdateSpritePos.GetInstance;
        drawSprite = DrawSprite.GetInstance;
    }
    public void Draw()
    {
        drawSprite.Draw((ISprite)sprite, Color.White);
    }

    public void Update()
    {
        position.Update((ISprite)sprite);
    }

    public void SetPosition(SpriteAction action)
    {
        sprite.SetSpriteAction(action);
    }
}
