using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public sealed class EnemyController: IController
    {
    private List<IConcreteSprite> enemies;
    private IConcreteSprite currentEnemy;
    private int counter;
    private Random rand;
    private bool isMoving;
    private List<SpriteAction> actions;
    private SpriteAction action;
    private FireProjectile fireProjectile;

    private EnemyController()
    {
        enemies = new List<IConcreteSprite>();
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

    public void AddEnemy(IConcreteSprite enemy)
    {
        // kill the current enemy before adding a new enemy to the list
        if (currentEnemy != null) killEnemy();
        enemies.Add(enemy);
        currentEnemy = enemy;
        initEnemy();
            
    }

    public void Update()
    {
        /*set a random state for the enemy 
       Update counter every 100 frames
       */

        if (counter == 100)
        {
            action = actions[rand.Next(4)];

            if (isMoving)
            {
                currentEnemy.SetSpriteState(action, currentEnemy.moving);  
            }
            else
            {
                currentEnemy.SetSpriteState(action, currentEnemy.still);
                // Fire a projectile while still
                fireProjectile.Execute();
            }

            // reset the counter and flip if enemy will move or not
            counter = 0;
            isMoving = !isMoving;
        }

            // update the enemy
            currentEnemy.Update();
            counter++;

        }
        
    public void nextEnemy()
    {
        int listSize = enemies.Count;
        int currentIndex = enemies.IndexOf(currentEnemy) + 1;

        if(currentIndex < listSize)
        {
            killEnemy();
            currentEnemy = enemies[currentIndex];
            initEnemy();
            
        }
       
    }

    public void previousEnemy()
    {
        int currentIndex = enemies.IndexOf(currentEnemy) - 1;

        if (currentIndex >= 0)
        {
            killEnemy();
            currentEnemy = enemies[currentIndex];
            initEnemy();
        }

    }

    private void killEnemy()
    {
        currentEnemy.SetSpriteState(action, currentEnemy.dead);
    }

    private void initEnemy()
    {
        currentEnemy.SetSpriteState(SpriteAction.moveLeft, currentEnemy.still);
    }

    public void SetFireCommand(FireProjectile fireProjectile)
    {
        this.fireProjectile = fireProjectile;
    }
}
    

