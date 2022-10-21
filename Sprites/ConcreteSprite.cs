using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

public class ConcreteSprite: AbstractSprite, IConcreteSprite
    {

    /*Declare state variables*/
    public ISpriteState still { get; set; }

    public ISpriteState OpenDoor { get; set; }

    public ISpriteState ClosedDoor { get; set; }

    public ISpriteState moving { get; set; }
    public ISpriteState damaged { get; set; }
    public ISpriteState dead { get; set; }
    public ISpriteState stillAnimated { get; set; }
    public ISpriteState attack { get; set; }
    public ISpriteState use { get; set; }
    public int health { get; set; }
    public bool isDead { get; set; }

    /*Projectile inventory
     Use ArrayIndex enums*/
    private int projectileIndex;
    public IProjectile[] projectiles { get; set; }

    private IDraw drawSprite = new DrawSprite();
    private IPosition posUpdate = UpdateSpritePos.GetInstance;

    /*Variable that holds the current state*/
    private ISpriteState state;

    

    public ConcreteSprite(SpriteBatch spriteBatch, Vector2 position, List<Texture2D>[] textures, bool isDoorOpen) : base(spriteBatch, position, textures) {
        OpenDoor = new OpenState(this);
        ClosedDoor = new ClosedState(this);
        if (isDoorOpen)
        {
            state = OpenDoor;//pass in default sprite state as a parameter (good for doors so they can be open or closed)
        }
        else
        {
            state = ClosedDoor;
        }
    }

    public ConcreteSprite(SpriteBatch spriteBatch, Vector2 position, List<Texture2D>[] textures) : base(spriteBatch, position, textures)
    {
        still = new StillState(this);
        stillAnimated = new StillAnimated(this);
        moving = new MovingState(this);
        damaged = new DamagedState(this);
        attack = new AttackState(this);
        dead = new DeadState(this);
        use = new UseState(this);

        health = 3;
        isDead = false;

        state = still;

        projectiles = new IProjectile[4];
        projectileIndex = (int)ArrayIndex.arrow;
    }

    public void SetSpriteState(SpriteAction action, ISpriteState state)
    {

        if (!isDead)
        {
            state.SetPreviousState(this.state);
            this.state = state;
            SetSpriteAction(action);
        }
        
    }
    public override void Update(GameTime gameTime)
    {
       state.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {    
       state.Draw(gameTime);
    }

    public void AddProjectile(IProjectile projectile, ArrayIndex arrayIndex)
    {
        projectiles[(int)arrayIndex] = projectile;
    }
    public void SetProjectileIndex(ArrayIndex arrayIndex)
    {
        projectileIndex = (int)arrayIndex;
    }
    public void ProjectileAttack()
    {
        if (projectiles[projectileIndex] != null)
        {
            projectiles[projectileIndex].FireCommand().Execute();
        }
    }
}

