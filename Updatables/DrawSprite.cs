using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public sealed class DrawSprite: IDraw
    {
    private int currentFrame;
    private int totalFrames;
    private SpriteBatch spriteBatch;
    private List<Texture2D> textureToDraw;
    private Vector2 screenCord;
    int counter = 0;
   

    private DrawSprite()
    {
    }

    private static readonly DrawSprite instance = new DrawSprite();
    public static DrawSprite GetInstance
    {
        get
        {
            return instance;
        }
    }

    public void Draw(ISprite sprite, Color color)
    {
        //get the current frames from the sprite instance variables
        currentFrame = sprite.currentFrame;
        totalFrames = sprite.totalFrames;
        spriteBatch = sprite.spriteBatch;
        textureToDraw = sprite.textureToDraw;
        screenCord = sprite.screenCord;

        // Draw the sprite
        spriteBatch.Draw(textureToDraw[currentFrame], screenCord, color);//color is data driven



        //update and save the frames
        

        if (counter > 10)
        {
            counter = 0;
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
           
        }
        counter++;
       
        

        //update the instance variables for the sprite
        sprite.currentFrame = currentFrame;
        
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

        //update and save the frames
        if (counter > 10)
        {
            counter = 0;
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
        }
        counter++;
        //update the instance variables for the sprite
        sprite.currentFrame = currentFrame;

    }

}

