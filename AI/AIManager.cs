using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public sealed class AIManager : IAIManager
{
    private enum CONSTANTS
    {
    }
    //--------------------------------VARIABLES--------------------------------
    private static AIManager instance = new AIManager();
    private IRoomObject currentRoom;

    //--------------------------------INITIALIZER--------------------------------
    private AIManager()
    {
    }

    public static AIManager Instance { get { return instance; } }

    //--------------------------------METHODS--------------------------------

    /* called by Update in Game1
     * updates collision of game objects inside current room */
    public void Update(GameTime gameTime)
    {
        this.currentRoom = RoomObjectManager.Instance.currentRoom();

        foreach (IConcreteSprite enemy in currentRoom.EnemyList)
        {
            enemy.ai.Update(gameTime);
        }
    }
}