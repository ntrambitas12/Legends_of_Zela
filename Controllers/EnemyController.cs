using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class EnemyController: IController
    {
    private List<ICommand> enemyCommand;

    public EnemyController()
    {
        enemyCommand = new List<ICommand>();
    }

    public void AddEnemy(ICommand command)
    {
        enemyCommand.Add(command);
    }

    public void Update()
    {
        foreach (ICommand enemy in enemyCommand)
        {
            enemy.Execute();
        }
    }
    }

