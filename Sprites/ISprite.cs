﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


     public interface ISprite
    {
    public int currentFrame { get; set; }
    public int totalFrames { get; set; }
    public int spritePos { get; set; }
    public ICollision collider { get; set; }
    public IAI ai { get; set; }
    public SpriteBatch spriteBatch { get; set; }
    public Vector2 screenCord { get; set; }
    public Vector2 orgScreenCord { get; set; }
    public List<Texture2D> textureToDraw { get; set; }
    void Draw(GameTime gameTime);
    void Update(GameTime gameTime);
    void SetSpriteAction(SpriteAction action);
}
    

