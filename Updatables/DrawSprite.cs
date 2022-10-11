﻿using Microsoft.Xna.Framework.Graphics;
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
    private float timeElapsed;

    private DrawSprite() {
        currentFrame = 0;
        totalFrames = 0;
        timeElapsed = 0;
    }

    private static readonly DrawSprite instance = new DrawSprite();
    public static DrawSprite GetInstance
    {
        get
        {
            return instance;
        }
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
        spriteBatch.Draw(textureToDraw[currentFrame], screenCord, color); /* Color here is data driven */

        // Update and save the frames
        
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
       

        if (timeElapsed > .1)
        {
            timeElapsed = 0;
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
           
        }

        if (animated)
        {
            // Update the instance variables for the sprite
            sprite.currentFrame = currentFrame;
        }
    }
   
}

