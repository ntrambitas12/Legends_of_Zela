using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class TriforceDropType : IItemType
{
    private IDrop triforce;

    public TriforceDropType(IDrop triforce)
    {
        this.triforce = triforce;
    }

    public static IItemType CreateDrop(IDrop drop)
    {
        return new TriforceDropType(drop);
    }

    public void Update(GameTime gameTime)
    {
        if (triforce.ShouldDraw())
        {
            IConcreteSprite link = (IConcreteSprite)RoomObjectManager.Instance.currentRoom().Link;
            ISprite collidingObject = triforce.collider.isIntersecting(new List<ISprite> { RoomObjectManager.Instance.currentRoom().Link });

            if (collidingObject != null)
            {
                SoundManager.Instance.PauseSounds();
                SoundManager.Instance.PlayOnce("LOZ_Fanfare");
                triforce.SetShouldDraw(false);
                RoomObjectManager.Instance.DeleteGameObject((int)RoomObjectTypes.typePickup, triforce);
                link.triforce = true;
                // Add to Link's inventory here
            }
        }
    }
}