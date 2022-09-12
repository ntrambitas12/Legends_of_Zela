﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public abstract class AbstractSprite: ISprite
    {
    protected IAnimate animateObj;
    protected IPosition updateObj; 
    protected int currentFrame;
    protected int totalFrames;
    protected int spritePos;
    private SpriteBatch spriteBatch;
    protected Vector2 screenCord;
    private List<Texture2D>[] textures;
    private List<Texture2D> textureToDraw;

    public AbstractSprite(SpriteBatch spriteBatch, Vector2 position, List<Texture2D>[] textures)
    {
        this.spriteBatch = spriteBatch;
        this.screenCord = position;
        this.spritePos = 0;
        this.textures = textures;
        this.SetSpritePosition(spritePos);
        

    }
    public void Draw()
    {
        spriteBatch.Draw(textureToDraw[currentFrame], screenCord, Color.White);


    }
    
    public abstract void Update();
    public void SetSpritePosition(int spritePos)
    {
        this.spritePos = spritePos;
        textureToDraw = textures[spritePos];
        totalFrames = textureToDraw.Count;
    }
    }

