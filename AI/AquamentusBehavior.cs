using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AquamentusBehavior : IAI
{

    private enum CONSTANTS
    {
    }

    //--------------------------------VARIABLES--------------------------------
    //the entity this is for
    public ISprite entity { get; set; }

    private bool pauseEnemies;
    
    private IProjectile centerFireball;
    private IProjectile upperFireball;
    private IProjectile lowerFireball;
    private Random rand;
    private float timeElapsed;


    //--------------------------------INITIALIZER--------------------------------
    //must be passed an entity for 'this' to be attached to, and size of collider 'colliderDimensions'
    public AquamentusBehavior(ISprite entity)
    {
        this.entity = entity;
        rand = new Random();
        //upperFireball = (IProjectile) SpriteFactory.Instance.CreateUpperFireballProjectile(100, entity);
        //lowerFireball = (IProjectile) SpriteFactory.Instance.CreateLowerFireballProjectile(100, entity);
        //RoomObjectManager.Instance.getRoom(23).AddGameObject((int) RoomObjectTypes.typeEnemyProjectile, upperFireball, "Upper Fireball");
        //RoomObjectManager.Instance.getRoom(23).AddGameObject((int)RoomObjectTypes.typeEnemyProjectile, lowerFireball, "Lower Fireball");
        timeElapsed = 0;
    }

    //--------------------------------METHODS--------------------------------
    public void Update(GameTime gameTime)
    {
        this.pauseEnemies = RoomObjectManager.Instance.currentRoom().IsPauseEnemies();
        if (!pauseEnemies && timeElapsed > 3/* && rand.Next(25) == 5*/)
        {
            centerFireball.FireCommand().Execute();
            if (RoomObjectManager.Instance.currentRoomID() == 23 && RoomObjectManager.Instance.currentRoom().EnemyProjectileList.Count < 2)
            {
                upperFireball = (IProjectile)SpriteFactory.Instance.CreateUpperFireballProjectile(100, entity, "UpperFireball", (int)RoomObjectTypes.typeEnemyProjectile);
                lowerFireball = (IProjectile)SpriteFactory.Instance.CreateLowerFireballProjectile(100, entity, "LowerFireball", (int)RoomObjectTypes.typeEnemyProjectile);
                RoomObjectManager.Instance.currentRoom().AddGameObject((int)RoomObjectTypes.typeEnemyProjectile, upperFireball, "Upper Fireball");
                RoomObjectManager.Instance.currentRoom().AddGameObject((int)RoomObjectTypes.typeEnemyProjectile, lowerFireball, "Lower Fireball");
            }
            if (upperFireball != null) upperFireball.FireCommand().Execute();
            if (lowerFireball != null) lowerFireball.FireCommand().Execute();
            timeElapsed = 0;
        }
        timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public void SetProjectile(IProjectile projectile)
    {
        this.centerFireball = projectile;
    }
}
