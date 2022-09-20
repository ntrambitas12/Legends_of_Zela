using Microsoft.Xna.Framework.Graphics;
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
    private IDraw drawSprite = new DrawSprite();
    private IPosition posUpdate = new UpdateSpritePos();

    /*Variable that holds the current state*/
    public ISpriteState state;
    public ConcreteSprite(SpriteBatch spriteBatch, Vector2 position, List<Texture2D>[] textures) : base(spriteBatch, position, textures) {
        still = new StillState(this);
        moving = new MovingState(this);
        damaged = new DamagedState(this);
        state = still;
    }
   
    public void SetSpriteState(SpriteAction action, ISpriteState state)
    {
        SetSpriteAction(action);
        this.state = state;
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

