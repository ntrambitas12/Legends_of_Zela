﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class EnemyCommand: ICommand
    {
    private ISprite enemy;
    private int counter;
    private Random rand;

    public EnemyCommand(ISprite enemy)
    {
        this.enemy = enemy;
        this.counter = 0;
        this.rand = new Random();
    }
    public void Execute()
    {
        // Have position of an enemy change once every 10 frames
        if (counter % 10 == 0)
        {
            /*set a random postion between 0 and 4*/
            enemy.SetSpritePosition(rand.Next(4));
        }
        counter++;
        
        /*update the enemy*/
        enemy.Update();

    }
    }

