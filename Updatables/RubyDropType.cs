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

    public static IItemType CreateDrop(IDrop drop)
    {
        return new RubyDropType(drop);
    }

    public void Update(GameTime gameTime)
    {
        if (ruby.ShouldDraw())
        {
            IConcreteSprite Link = (IConcreteSprite)RoomObjectManager.Instance.currentRoom().Link;
            ISprite collidingObject = ruby.collider.isIntersecting(new List<ISprite> { Link });

            if (collidingObject != null)
            {
                SoundManager.Instance.PlayOnce("LOZ_Get_Rupee");

                ruby.SetShouldDraw(false);
                RoomObjectManager.Instance.DeleteGameObject((int)RoomObjectTypes.typePickup, ruby);
                Link.rubies++;
            }
        }
    }
}
