using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class DrawSprite: IDraw
    { 
    private int currentFrame;
    private int totalFrames;
    private SpriteBatch spriteBatch;
    private List<Texture2D> textureToDraw;
    private Vector2 screenCord;
    private float timeElapsed;

    public DrawSprite() {
        currentFrame = 0;
        totalFrames = 0;
        timeElapsed = 0;
    }
   
    public void Draw(ISprite sprite, Color color, bool animated, GameTime gameTime)
    {
        // Get the current frames from the sprite instance variables
        if (animated)
        {
            currentFrame = sprite.currentFrame;
            totalFrames = sprite.totalFrames;
        }
        else
        {
            currentFrame = 0;
            totalFrames = 0;
        }
        spriteBatch = sprite.spriteBatch;
        textureToDraw = sprite.textureToDraw;
        screenCord = sprite.screenCord;

        // Draw the sprite
        spriteBatch.Draw(textureToDraw[currentFrame], screenCord, null, color, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0); /* Color here is data driven */

        // Update and save the frames
        if (animated && timeElapsed > .1) {
            timeElapsed = 0;
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
            sprite.currentFrame = currentFrame;
        }
        timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
   
}

