using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class NextEnemy : ICommand
{
    private EnemyController controller;

    public NextEnemy(EnemyController controller)
    {
        this.controller = controller;
    }

    public void Execute()
    {
        controller.nextEnemy();
    }
}

