using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class RubyDropType : IItemType
{
    private IDrop ruby;

    public RubyDropType(IDrop ruby)
    {
        this.ruby = ruby;
    }

    public void Update(GameTime gameTime)
    {
        if (ruby.ShouldDraw())
        {
            IConcreteSprite Link = (IConcreteSprite)RoomObjectManager.Instance.currentRoom().Link;
            ISprite collidingObject = ruby.collider.isIntersecting(new List<ISprite> { Link });

            if (collidingObject != null)
            {
                ruby.SetShouldDraw(false);
                Link.rubies++;
            }
        }
    }
}
