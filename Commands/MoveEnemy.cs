using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class MoveEnemy: ICommand
    {
    private ISprite enemy;
    private int counter;
    private Random rand;
    private int pos;

    public MoveEnemy(ISprite enemy)
    {
        this.enemy = enemy;
        this.counter = 0;
        this.rand = new Random();   
        this.pos = 0;
    }
    public void Execute()
    {
        /*set a random postion between 0 and 3
         Update counter every 100 frames
         */

        if (counter == 100)
        {
            counter = 0;
             pos = rand.Next(4);
        }
        
          
            enemy.SetSpritePosition(pos);
        
        counter++;
        

    }
    }

