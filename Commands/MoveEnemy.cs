using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class MoveEnemy: ICommand
    {
    private IConcreteSprite enemy;
    private int counter;
    private Random rand;
    private bool isMoving;
    private List<SpriteAction> actions;
    private SpriteAction action;

    public MoveEnemy(IConcreteSprite enemy)
    {
        this.enemy = enemy;
        counter = 0;
        rand = new Random();
        isMoving = false;
        actions = new List<SpriteAction>();
        actions.Add(SpriteAction.stillDown);
        actions.Add(SpriteAction.stillUp);
        actions.Add(SpriteAction.stillLeft);
        actions.Add(SpriteAction.stillRight);
    }
    public void Execute()
    {
        /*set a random action for the enemy 
         Update counter every 100 frames
         */

        if (counter == 100)
        {
            action = actions[rand.Next(4)];

            counter = 0;
            
            isMoving = !isMoving;
        }


        /*Call function to move, will refactor once state code exists*/
        if (isMoving)
        {
            enemy.SetSpriteState(action, enemy.moving);
            enemy.Update();
        } else
        {
            enemy.SetSpriteState(action, enemy.still);
            enemy.Update();
        }
        counter++;
        

    }
    }

