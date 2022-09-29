using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DamagedState : ISpriteState
{
    private ISprite sprite;
    private IPosition position;
    private IDraw drawSprite;

    public DamagedState(ISprite sprite)
    {
        this.sprite = sprite;
        position = UpdateSpritePos.GetInstance;
        drawSprite = DrawSprite.GetInstance;
    }

    public void Update()
    {
        sprite.SetSpriteAction(SpriteAction.damageRight);
        position.Update(sprite);
    }

    public void Draw()
    {
        drawSprite.Draw(sprite, Color.Red);
    }

    public void SetPosition(SpriteAction action)
    {
        sprite.SetSpriteAction(action);
    }
}


