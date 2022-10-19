using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

public class RoomObject : IRoomObject
{
    public List<IController> ControllerList { get; set; }
    public ISprite Link { get; set; }
    public List<ISprite> LinkProjectileList { get; set; }
    public List<ISprite> EnemyList { get; set; }
    public List<ISprite> EnemyProjectileList { get; set; }
    public List<ISprite> StaticTileList { get; set; }
    public List<ISprite> DynamicTileList { get; set; }
    public List<ISprite> PickupList { get; set; }
    public List<ISprite> CollidibleList { get; set; }
    public List<ISprite> TopLayerNonCollidibleList { get; set; }

    private List<(ISprite, int)> toBeDeleted;
    private Dictionary<int, List<ISprite>> listDict;
    
    //enemy AI related data
    private List<SpriteAction> enemyActions;
    private SpriteAction enemyAction;
    private Random rand;


    public RoomObject()
    {
        //intialize sprite and controller lists
        ControllerList = new List<IController>();
        LinkProjectileList = new List<ISprite>();
        EnemyList = new List<ISprite>();
        EnemyProjectileList = new List<ISprite>();
        StaticTileList = new List<ISprite>();
        DynamicTileList = new List<ISprite>();
        PickupList = new List<ISprite>();
        CollidibleList = new List<ISprite>();
        TopLayerNonCollidibleList = new List<ISprite>();

        //intialize structures to add and delete
        listDict = new Dictionary<int, List<ISprite>>();
        toBeDeleted = new List<(ISprite, int)>();

        //set up toBeAdded dictionary
        listDict.Add((int)RoomObjectTypes.typeLinkProjectile, LinkProjectileList);
        listDict.Add((int)RoomObjectTypes.typeEnemy, EnemyList);
        listDict.Add((int)RoomObjectTypes.typeEnemyProjectile, EnemyProjectileList);
        listDict.Add((int)RoomObjectTypes.typeTileStatic, StaticTileList);
        listDict.Add((int)RoomObjectTypes.typeTileDynamic, DynamicTileList);
        listDict.Add((int)RoomObjectTypes.typePickup, PickupList);
        listDict.Add((int)RoomObjectTypes.typeCollisionBox, CollidibleList);
        listDict.Add((int)RoomObjectTypes.typeTopLayerNonCollidible, TopLayerNonCollidibleList);

        //set up the logic for the enemy AI
        rand = new Random();
        enemyActions = new List<SpriteAction>();
        enemyActions.Add(SpriteAction.moveDown);
        enemyActions.Add(SpriteAction.moveLeft);
        enemyActions.Add(SpriteAction.moveRight);
        enemyActions.Add(SpriteAction.moveUp);



    }
    public void AddController(IController controller)
    {
        ControllerList.Add(controller);
    }
    public void AddGameObject(int objectType, ISprite gameObject)
    {
        if (listDict.TryGetValue(objectType, out List<ISprite> list))
        {
            list.Add(gameObject);
        }
    }

    public void DeleteGameObject(int objectType, ISprite gameObject)
    {
        toBeDeleted.Add((gameObject, objectType));
    }

    public void Update(GameTime gameTime)
    {
        //update all controllers
        foreach(var controller in ControllerList)
        {
            controller.Update(gameTime);
        }

        Link.Update(gameTime);

        //update all enemies
        foreach(IConcreteSprite enemy in EnemyList)
        {

            /*
             * Using rand.next as a mechanism to "randomly" 
             * have each enemy change its state.
             * Couldnt think of a better ai, this will do
             * for now.
           */

            if (rand.Next(25) == 5)
            {
                enemyAction = enemyActions[rand.Next(4)];

                //if 0, then enemy will move
                if (rand.Next(2) == 0)
                {
                    enemy.SetSpriteState(enemyAction, enemy.moving);
                }
                //if 1, enemy will stay still
                else
                {
                    enemy.SetSpriteState(enemyAction, enemy.still);
                }

                

            }

            enemy.Update(gameTime);
         
        }

        //update projectiles
        foreach(var linkProjectile in LinkProjectileList)
        {
            linkProjectile.Update(gameTime);
        }

        foreach(var enemyProjectile in EnemyProjectileList)
        {
            enemyProjectile.Update(gameTime);
        }

        //update pickup items
        foreach(var item in PickupList)
        {
            item.Update(gameTime);
        }

        //update dynamic tiles
        foreach(var tile in DynamicTileList)
        {
            tile.Update(gameTime);
        }

        Delete();
    }

    public void Draw(GameTime gameTime)
    {
        //  background
        /* ADD CODE HERE ONCE BACKGROUND EXISTS*/

        foreach (var controller in ControllerList)
        {
            controller.Draw(gameTime);
        }
        //  tiles (both types)
        foreach (var tile in DynamicTileList)
        {
            tile.Draw(gameTime);
        }

        foreach (var tile in StaticTileList)
        {
            tile.Draw(gameTime);
        }
        //  projectiles (both types)
        foreach (var linkProjectile in LinkProjectileList)
        {
            linkProjectile.Draw(gameTime);
        }

        foreach (var enemyProjectile in EnemyProjectileList)
        {
            enemyProjectile.Draw(gameTime);
        }
        //  pickup items
        foreach (var item in PickupList)
        {
            item.Draw(gameTime);
        }
        //  enemies
        foreach (var enemy in EnemyList)
        {
            enemy.Draw(gameTime);
        }
        //  link
        Link.Draw(gameTime);
        //  top of doorways (so that it is on the top-most layer and Link disappears below it)
        foreach (var item in TopLayerNonCollidibleList)
        {
            item.Draw(gameTime);
        }
    }
    public void ResetControllers()
    {
        foreach (var controller in ControllerList)
        {
            controller.resetController();
        }
    }
    private void Delete()
    {
        //delete the sprites on the delete list
        foreach (var item in toBeDeleted)
        {
            //get the list the object belongs in
            int listID = item.Item2;

            //grab the list
            listDict.TryGetValue(listID, out List<ISprite> list);

            // delete item from the list
            list.Remove(item.Item1);
        }
        //after iterating the delete list, clear it!
        toBeDeleted.Clear();
    }


}

