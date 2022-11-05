using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RandomMove1 : IAI
{

    private enum CONSTANTS
    {
    }

    //--------------------------------VARIABLES--------------------------------
    //the entity this is for
    public ISprite entity { get; set; }

    private bool pauseEnemies;
    private SpriteAction enemyAction;

    private Random rand;


    //--------------------------------INITIALIZER--------------------------------
    //must be passed an entity for 'this' to be attached to, and size of collider 'colliderDimensions'
    public RandomMove1(ISprite entity)
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
            enemyAction = (SpriteAction)rand.Next(3);
            //if 0, then enemy will move
            if (rand.Next(2) == 0)
            {
                ((IConcreteSprite)entity).SetSpriteState(enemyAction, ((IConcreteSprite)entity).moving);
            }
            //if 1, enemy will stay still
            else
            {
                ((IConcreteSprite)entity).SetSpriteState(enemyAction, ((IConcreteSprite)entity).still);
            }
        }
    }
}
