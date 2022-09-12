using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class MoveEnemy: ICommand
    {
    private IAnimate animateObj;
    private IPosition updateObj;
    private ISprite enemy;
    private int counter;
    private Random rand;

    public MoveEnemy(ISprite enemy)
    {
        this.enemy = enemy;
        this.counter = 0;
        this.rand = new Random();
        animateObj = new AnimateSprite();
        updateObj = new UpdateSpritePos();
    }
    public void Execute()
    {
        // Have position of an enemy change once every 10 frames
        if (counter == 100)
        {
            counter = 0;
            /*set a random postion between 0 and 3*/
            enemy.SetSpritePosition(rand.Next(4));
        }
        counter++;
        
        /*update the enemy position on the screen*/
        updateObj.Update(enemy);

        /*update the frame of the enemy*/
        animateObj.Animate(enemy);

    }
    }

