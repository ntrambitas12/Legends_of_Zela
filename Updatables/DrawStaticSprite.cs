using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

    public sealed class DrawStaticSprite: IDraw
    {
    private SpriteBatch spriteBatch;
    private List<Texture2D> textureToDraw;
    private Vector2 screenCord;

    private DrawStaticSprite()
    { }

    private static readonly DrawStaticSprite instance = new DrawStaticSprite();
    public static DrawStaticSprite GetInstance
    {
        get
        {
            return instance;
        }
    }
    public void Draw(ISprite sprite, Color color)
    {
        //get the current frame from the sprite instance variables
        spriteBatch = sprite.spriteBatch;
        textureToDraw = sprite.textureToDraw;
        screenCord = sprite.screenCord;

        // Draw the sprite
        spriteBatch.Draw(textureToDraw[0], screenCord, color);//color is data driven

    }
}

