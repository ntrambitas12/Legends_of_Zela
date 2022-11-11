using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

public class DeathCloudDropType : IItemType
{
    IDrop deathCloud;
    float timeElapsed = 0;
    public DeathCloudDropType(IDrop deathCloud)
    {
        this.deathCloud = deathCloud;
    }

    public void Update(GameTime gameTime)
    {
        if (timeElapsed > 0.75)
        {
            RoomObjectManager.Instance.currentRoom().DeleteGameObject((int)RoomObjectTypes.typePickup, deathCloud);
        }
        timeElapsed += (float) gameTime.ElapsedGameTime.TotalSeconds;
    }
}