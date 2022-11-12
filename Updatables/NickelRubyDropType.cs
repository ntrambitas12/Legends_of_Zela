using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class NickelRubyDropType : IItemType
{
    private IDrop nickelRuby;

    public NickelRubyDropType(IDrop nickelRuby)
    {
        this.nickelRuby = nickelRuby;
    }

    public void Update(GameTime gameTime)
    {
        if (nickelRuby.ShouldDraw())
        {
            IConcreteSprite Link = (IConcreteSprite)RoomObjectManager.Instance.currentRoom().Link;
            ISprite collidingObject = nickelRuby.collider.isIntersecting(new List<ISprite> { Link });

            if (collidingObject != null)
            {
                SoundManager.Instance.PlayOnce("LOZ_Get_Rupee");

                nickelRuby.SetShouldDraw(false);
                Link.rubies += 5;
            }
        }
    }
}

