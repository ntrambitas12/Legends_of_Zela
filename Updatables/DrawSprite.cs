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
    private int counter;

    public DrawSprite()
    {
        counter = 0;
    }

    public void Draw(ISprite sprite)
    {
        //get the current frames from the sprite instance variables
        currentFrame = sprite.currentFrame;
        totalFrames = sprite.totalFrames;
        spriteBatch = sprite.spriteBatch;
        textureToDraw = sprite.textureToDraw;
        screenCord = sprite.screenCord;

        // Draw the sprite
        spriteBatch.Draw(textureToDraw[currentFrame], screenCord, Color.White);

        counter++;
        //update and save the frames
        if (counter == 10)
        {
            counter = 0;
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
        }

        //update the instance variables for the sprite
        sprite.currentFrame = currentFrame;
        
    }

}

