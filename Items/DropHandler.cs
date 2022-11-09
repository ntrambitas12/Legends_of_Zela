﻿using System;
using Microsoft.Xna.Framework;

public static class DropHandler
{
    public static void Drop(IRoomObject currRoom, Vector2 pos)
    {
        Random rand = new Random();
        SpriteFactory spriteFactory = SpriteFactory.Instance;
        switch (rand.Next() % 10)
        {
            case 0: // drop clock
                ISprite clock = spriteFactory.CreateClockDrop(pos);
                currRoom.AddGameObject((int)RoomObjectTypes.typePickup, clock, "Clock");
                break;
            case 1: // drop heart
                ISprite heart = spriteFactory.CreateHeartDrop(pos);
                currRoom.AddGameObject((int)RoomObjectTypes.typePickup, heart, "Heart");
                break;
            case 2: // drop heart container
                ISprite heartContainer = spriteFactory.CreateHeartContainerDrop(pos);
                currRoom.AddGameObject((int)RoomObjectTypes.typePickup, heartContainer, "Heart Container");
                break;
            case 3: // drop rupee
                ISprite rupee = spriteFactory.CreateRubyDrop(pos);
                currRoom.AddGameObject((int)RoomObjectTypes.typePickup, rupee, "Rupee");
                break;
            case 4: // drop nickel rupee
                ISprite nickelRupee = spriteFactory.CreateNickelRubyDrop(pos);
                currRoom.AddGameObject((int)RoomObjectTypes.typePickup, nickelRupee, "Nickel Rupee");
                break;
            default: // don't drop anything
                break;
        }
    }
}

