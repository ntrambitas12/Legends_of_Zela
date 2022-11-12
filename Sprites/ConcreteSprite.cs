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
    public int maxHealth { get; set; }
    public bool isDead { get; set; }
    public int keys { get; set; }
    public int rubies { get; set; }
    public int bombs { get; set; }
    public bool map { get; set; }
    public bool compass { get; set; }
    public bool triforce { get; set; }

    public Boolean isDamaged { get; set; }

    /*Projectile inventory
     Use ArrayIndex enums*/
    private int projectileIndex;
    public IProjectile[] projectiles { get; set; }

    public SpriteAction direction { get; set; }

    private float timeElapsed;

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
        direction = SpriteAction.left;
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

        health = 6;
        maxHealth = 6;
        isDead = false;

        keys = 0;
        rubies = 0;
        bombs = 0;
        map = false;
        compass = false;
        triforce = false;

        state = still;
        direction = SpriteAction.left;

        projectiles = new IProjectile[5];
        projectileIndex = (int)ArrayIndex.arrow;

        projectiles[(int)ArrayIndex.swordShoot] = (IProjectile) SpriteFactory.Instance.CreateSwordShootProjectile(999, this);
    }

    public void SetSpriteState(SpriteAction action, ISpriteState state)
    {
        
        

        if (!isDead)
        {
            state.SetPreviousState(this.state);
            this.state = state;
            SetSpriteAction(action);
            SoundManager.Instance.playStateSounds(action, state);
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
    public ArrayIndex ProjectileIndex()
    {
        return (ArrayIndex) this.projectileIndex;
    }
    public void SetProjectileIndex(ArrayIndex arrayIndex)
    {
        projectileIndex = (int)arrayIndex;
    }
    public void ProjectileAttack()
    {
        if (projectiles[(int)projectileIndex] != null)
        {
            switch ((ArrayIndex)projectileIndex)
            {
                case ArrayIndex.arrow:
                    if (rubies > 0)
                    {
                        projectiles[(int)projectileIndex].FireCommand().Execute();
                        rubies--;
                    }
                    break;
                case ArrayIndex.bomb:
                    if (bombs > 0 && projectiles[(int)projectileIndex].FireCommand().Counter() == 0)
                    {
                        projectiles[(int)projectileIndex].FireCommand().Execute();
                        bombs--;
                    }
                    break;
                case ArrayIndex.boomerang:
                    projectiles[(int)projectileIndex].FireCommand().Execute();
                    break;
                default:
                    break;
            }
        }
    }
    public void SwordAttack()
    {
        if (projectiles[(int) ArrayIndex.sword] != null)
        {
            if (this.health < this.maxHealth) projectiles[(int) ArrayIndex.sword].FireCommand().Execute();
            else projectiles[(int)ArrayIndex.swordShoot].FireCommand().Execute();
        }
    }

    public void TakeDamage()
    {
        SpriteAction newPos;
        SpriteAction currentPos = this.direction;
        float orgX;
        float orgY;
        

        /* Decrement the entitys health field */
        this.health--;
        SoundManager.Instance.PlayOnce("LOZ_Enemy_Hit");
        //SoundManager.Instance.playPainSounds(this.maxHealth);

        /* Keep the sprite facing in the same direction when they take damage */
        int entityPos = this.spritePos;
        switch (entityPos)
        {
            case 0:
                newPos = SpriteAction.damageLeft;
                orgX = this.screenCord.X;
                orgY = this.screenCord.Y;
                this.screenCord = new Vector2((orgX + 20), orgY);
                break;
            case 1:
                newPos = SpriteAction.damageRight;
                orgX = this.screenCord.X;
                orgY = this.screenCord.Y;
                this.screenCord = new Vector2((orgX - 20), orgY);
                break;
            case 2:
                newPos = SpriteAction.damageUp;
                orgX = this.screenCord.X;
                orgY = this.screenCord.Y;
                this.screenCord = new Vector2(orgX, (orgY + 20));
                break;
            case 3:
                newPos = SpriteAction.damageDown;
                orgX = this.screenCord.X;
                orgY = this.screenCord.Y;
                this.screenCord = new Vector2(orgX, (orgY - 20));
                break;
            default:
                newPos = (SpriteAction)this.spritePos;
                break;

        }
        this.SetSpriteState(newPos, this.damaged);
        isDamaged = true;

       // timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
        //while (timeElapsed < 2)
        //{
        //    timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
        //}
        //this.SetSpriteState(currentPos, this.still);

    }

    public void SetDirection(SpriteAction direction)
    {
        this.direction = direction;
    }

    public void CarryToStart(IConcreteSprite wallmaster, IRoomObject room, RoomObjectManager roomSwitch)
    {
        room.PauseLink();
        while (this.screenCord.Y < 400)
        {
            this.screenCord = new Vector2(this.screenCord.X, (this.screenCord.Y - 5));
            wallmaster.screenCord = new Vector2(wallmaster.screenCord.X, (wallmaster.screenCord.Y - 5));
        }
        roomSwitch.setRoom(1, false);
        room = (RoomObject)roomSwitch.currentRoom();
        this.screenCord = new Vector2(1100, 350);
        room.UnpauseLink();


    }

}

