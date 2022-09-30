using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AttackState : ISpriteState
{
    private ISprite sprite;
    private IDraw drawSprite;

    public AttackState(ISprite sprite)
    {
        drawSprite = DrawStaticSprite.GetInstance;
        this.sprite = SpriteFactory.Instance.CreateGoriyaSprite();
    }

    public void Update()
    {
    }

    public void Draw()
    {
        drawSprite.Draw(sprite, Color.White);

    }
    
    public void SetPosition(SpriteAction action)
    {
        sprite.SetSpriteAction(action);
    }
}


