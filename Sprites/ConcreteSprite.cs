﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ConcreteSprite: AbstractSprite, IConcreteSprite
    {

    /*Intialize the states*/
    public ISpriteState still { get; set; }
    public ISpriteState moving { get; set; }
    public ISpriteState damaged { get; set; }
    public ISpriteState dead { get; set; }
    public ISpriteState stillAnimated { get; set; }


    private IDraw drawSprite = DrawSprite.GetInstance;
    private IPosition posUpdate = UpdateSpritePos.GetInstance;

    /*Variable that holds the current state*/
    public ISpriteState state;
    public ConcreteSprite(SpriteBatch spriteBatch, Vector2 position, List<Texture2D>[] textures) : base(spriteBatch, position, textures) {
        still = new StillState(this);
        stillAnimated = new StillAnimated(this);
        moving = new MovingState(this);
        damaged = new DamagedState(this);
        dead = new DeadState();

        state = still;
    }
   
    public void SetSpriteState(SpriteAction action, ISpriteState state)
    {
        if (this.state != state)
        {
            this.state = state;
        }
        SetSpriteAction(action);


    }
    public override void Update()
    {
       state.Update();
    }

    public override void Draw()
    {    
       state.Draw();
    }
}

