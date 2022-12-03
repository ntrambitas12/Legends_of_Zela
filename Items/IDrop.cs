using Microsoft.Xna.Framework;
using System;

public interface IDrop : IItem
{
    public String name { get; set; }
    public int RoomObjectType { get; set; }
    public Vector2 initScreenCoord { get; set; }
    public object Clone();
    
}

