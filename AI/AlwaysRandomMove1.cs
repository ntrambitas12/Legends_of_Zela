using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AlwaysRandomMove1 : IAI
{

    private enum CONSTANTS
    {
    }

    //--------------------------------VARIABLES--------------------------------
    //the entity this is for
    public ISprite entity { get; set; }

    private bool pauseEnemies;
    private SpriteAction enemyAction;
    private IProjectile projectile;

    private Random rand;


    //--------------------------------INITIALIZER--------------------------------
    //must be passed an entity for 'this' to be attached to, and size of collider 'colliderDimensions'
    public AlwaysRandomMove1(ISprite entity)
    {
        this.entity = entity;
        rand = new Random();
    }

    //--------------------------------METHODS--------------------------------
    public void Update(GameTime gameTime)
    {
        this.pauseEnemies = RoomObjectManager.Instance.currentRoom().IsPauseEnemies();
        if (!pauseEnemies && rand.Next(25) == 5)
        {
            enemyAction = (SpriteAction)rand.Next(4);
            ((IConcreteSprite)entity).SetSpriteState(enemyAction, ((IConcreteSprite)entity).moving);
            if (projectile != null) projectile.FireCommand().Execute();
        }
    }

    public void SetProjectile(IProjectile projectile)
    {
        this.projectile = projectile;
    }
}
