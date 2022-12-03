using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class Drop : AbstractItem, IDrop, ICloneable
{
    private Vector2 position;
    public String name { get; set; }
    public int RoomObjectType { get; set; }
    public Vector2 initScreenCoord { get; set; }
    private List<Texture2D>[] textures;
    public Drop(SpriteBatch spriteBatch, Vector2 position, List<Texture2D>[] textures) : base(spriteBatch, position, textures)
    {
        this.position = position;
        this.textures = textures;
        SetShouldDraw(true);
    }

    public object Clone()
    {
        return new Drop(spriteBatch, position, textures);
    }
}


