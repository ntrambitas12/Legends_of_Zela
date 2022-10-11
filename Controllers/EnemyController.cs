using CSE3902Project.Controllers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public sealed class EnemyController : AbstractController
{
    private int prevTime;
    private int deltaT;
    private Random rand;
    private bool isMoving;
    private List<SpriteAction> actions;
    private SpriteAction action;

    private EnemyController() : base()
    {
        prevTime = 0;
        deltaT = 0;
        rand = new Random();
        isMoving = false;
        actions = new List<SpriteAction>();
        actions.Add(SpriteAction.moveDown);
        actions.Add(SpriteAction.moveLeft);
        actions.Add(SpriteAction.moveRight);
        actions.Add(SpriteAction.moveUp);
    }
    private static readonly EnemyController instance = new EnemyController();
    public static EnemyController GetInstance
    {
        get
        {
            return instance;
        }
    }

    public override void Update(GameTime gameTime)
    {

        /*set a random state for the enemy 
        every 4 secomds
       */
        calcDelta(gameTime);

        if ( deltaT > 2)
        {
            action = actions[rand.Next(4)];

            if (isMoving)
            {
                currentSprite.SetSpriteState(action, currentSprite.moving);
            }
            else
            {
                currentSprite.SetSpriteState(action, currentSprite.still);
                currentProjectile.FireCommand().Execute(); // Coupling
            }

            //flip if enemy will move or not
            isMoving = !isMoving;

            resetDelta(gameTime);
            
        }

        // update the enemy
        currentSprite.Update(gameTime);

    }

    private void calcDelta(GameTime gameTime)
    {
        deltaT = gameTime.TotalGameTime.Seconds - prevTime;
    }

    private void resetDelta(GameTime gameTime)
    {
        prevTime = gameTime.TotalGameTime.Seconds;
        deltaT = 0;
    }

}



