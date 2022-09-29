using CSE3902Project.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public sealed class EnemyController: AbstractController
    {

    private int counter;
    private Random rand;
    private bool isMoving;
    private List<SpriteAction> actions;
    private SpriteAction action;

    private EnemyController() : base()
    {
       
        counter = 0;
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

    public override void Update()
    {
        /*set a random state for the enemy 
       Update counter every 100 frames
       */

        if (counter == 100)
        {
            action = actions[rand.Next(4)];

            if (isMoving)
            {
                currentSprite.SetSpriteState(action, currentSprite.moving);  
            }
            else
            {
                currentSprite.SetSpriteState(action, currentSprite.still);
            }

            // reset the counter and flip if enemy will move or not
            counter = 0;
            isMoving = !isMoving;
        }

            // update the enemy
            currentSprite.Update();
            counter++;

        }
   
}
    

