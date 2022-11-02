using CSE3902Project.Commands;
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
    public List<ISprite> EnemyList { get; set; }
    public List<ISprite> EnemyProjectileList { get; set; }
    public List<ISprite> StaticTileList { get; set; }
    public List<ISprite> DynamicTileList { get; set; }
    public List<ISprite> PickupList { get; set; }
    public List<ISprite>[] CollidibleList { get; set; }
    public List<ISprite> TopLayerNonCollidibleList { get; set; }
    public List<ISprite> replacesFloorList { get; set; }
    public List<ISprite> floorList { get; set; }
    public List<ISprite> ProjectileStopperList { get; set; }
    public Dictionary<ISprite, ISprite> EnemyToProjectile { get; set; }
    public Vector2 BaseCord { get; set; }

    private List<(ISprite, int)> toBeDeleted;
    private Dictionary<int, List<ISprite>> listDict;

    //enemy AI related data
    private List<SpriteAction> enemyActions;
    private SpriteAction enemyAction;
    private Random rand;
    private bool pauseEnemies;

    //constants
    private int leftDoorBoundary = 146;
    private int rightDoorBoundary = 624;
    private int upDoorBoundary = 114;
    private int downDoorBoundary = 434;

    //roomObjectManager
    private RoomObjectManager roomObjectManager;
    public RoomObject()
    {
        //intialize sprite and controller lists
        ControllerList = new List<IController>();
        EnemyList = new List<ISprite>();
        EnemyProjectileList = new List<ISprite>();
        StaticTileList = new List<ISprite>();
        DynamicTileList = new List<ISprite>();
        PickupList = new List<ISprite>();

        CollidibleList = new List<ISprite>[2];
        CollidibleList[0] = StaticTileList;
        CollidibleList[1] = DynamicTileList;

        TopLayerNonCollidibleList = new List<ISprite>();
        replacesFloorList = new List<ISprite>();
        floorList = new List<ISprite>();

        ProjectileStopperList = new List<ISprite>();
        EnemyToProjectile = new Dictionary<ISprite, ISprite>();

        //intialize structures to add and delete
        listDict = new Dictionary<int, List<ISprite>>();
        toBeDeleted = new List<(ISprite, int)>();

        //set up toBeAdded dictionary
        listDict.Add((int)RoomObjectTypes.typeEnemy, EnemyList);
        listDict.Add((int)RoomObjectTypes.typeEnemyProjectile, EnemyProjectileList);
        listDict.Add((int)RoomObjectTypes.typeTileStatic, StaticTileList);
        listDict.Add((int)RoomObjectTypes.typeTileDynamic, DynamicTileList);
        listDict.Add((int)RoomObjectTypes.typePickup, PickupList);
        listDict.Add((int)RoomObjectTypes.typeTopLayerNonCollidible, TopLayerNonCollidibleList);
        listDict.Add((int)RoomObjectTypes.typeReplacesFloor, replacesFloorList);
        listDict.Add((int)RoomObjectTypes.typeFloor, floorList);

        //set up the logic for the enemy AI
        rand = new Random();
        enemyActions = new List<SpriteAction>();
        enemyActions.Add(SpriteAction.moveDown);
        enemyActions.Add(SpriteAction.moveLeft);
        enemyActions.Add(SpriteAction.moveRight);
        enemyActions.Add(SpriteAction.moveUp);
        pauseEnemies = false;

        roomObjectManager = RoomObjectManager.Instance;

    }
    public void AddController(IController controller)
    {
        ControllerList.Add(controller);
    }

    public void AddEnemyProjectilePair(ISprite enemy, ISprite projectile)
    {
        if (!EnemyToProjectile.ContainsKey(enemy)) EnemyToProjectile.Add(enemy, projectile);
    }

    public void AddGameObject(int objectType, ISprite gameObject, String name)
    {
        if (listDict.TryGetValue(objectType, out List<ISprite> list))
        {
            list.Add(gameObject);
            if (objectType == (int)RoomObjectTypes.typeTileStatic &&
                !(name.Equals("Water"))) {
                ProjectileStopperList.Add(gameObject);
            }
        }
    }

    public void DeleteGameObject(int objectType, ISprite gameObject)
    {
        toBeDeleted.Add((gameObject, objectType));
    }

    public void Update(GameTime gameTime)
    {
        //update all controllers
        foreach (var controller in ControllerList)
        {
            controller.Update(gameTime);
        }

        //update Link
        if (Link != null) {
            Link.Update(gameTime);
        }

        //update all enemies
        foreach (IConcreteSprite enemy in EnemyList)
        {

            /*
             * Using rand.next as a mechanism to "randomly" 
             * have each enemy change its state.
             * Couldnt think of a better ai, this will do
             * for now. If a clock was used then enemies 
             * don't move.
           */

            if (!pauseEnemies && rand.Next(25) == 5)
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
        if (Link != null) { 
        foreach(IProjectile projectile in ((ConcreteSprite)Link).projectiles)
        {
            if (projectile != null) projectile.Update(gameTime);
        }
        }

        foreach (IProjectile enemyProjectile in EnemyProjectileList)
        {
            if (!pauseEnemies && rand.Next(25) == 5)
            {
                enemyProjectile.FireCommand().Execute();
            }
            enemyProjectile.Update(gameTime);
        }

        //update pickup items
        foreach (var item in PickupList)
        {
            item.Update(gameTime);
        }

        //update dynamic tiles
        foreach (var tile in DynamicTileList)
        {
            tile.Update(gameTime);
        }

        //update switching roooms
        CheckEnteredDoor();

        Delete();
    }

    public void Draw(GameTime gameTime)
    {

        foreach (var floor in floorList)
        {
            floor.Draw(gameTime);
        }

        foreach (var floor in replacesFloorList)
        {
            floor.Draw(gameTime);
        }

        foreach (var controller in ControllerList)
        {
            controller.Draw(gameTime);
        }
     

        foreach (var tile in DynamicTileList)
        {
            tile.Draw(gameTime);
        }
     
        foreach (var tile in StaticTileList)
        {
            tile.Draw(gameTime);
        }

        foreach (var enemyProjectile in EnemyProjectileList)
        {
            enemyProjectile.Draw(gameTime);
        }

        foreach (var item in PickupList)
        {
            item.Draw(gameTime);
        }

        foreach (var enemy in EnemyList)
        {
            enemy.Draw(gameTime);
        }

        

        if (Link != null)
        {
            foreach (IProjectile projectile in ((ConcreteSprite)Link).projectiles)
            {
                if (projectile != null) projectile.Draw(gameTime);
            }
            Link.Draw(gameTime);
        }

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

    public void TakeDamage(ISprite sprite)
    {
        IConcreteSprite castSprite = (IConcreteSprite)sprite;
        SpriteAction newPos;
        float orgX;
        float orgY;

        /* Decrement the sprites health field */
        castSprite.health--;

        /* Keep the sprite facing in the same direction when they take damage */
        int spritePos = sprite.spritePos;
        switch (spritePos)
        {
            case 0:
                newPos = SpriteAction.damageLeft;
                orgX = castSprite.screenCord.X;
                orgY = castSprite.screenCord.Y;
                castSprite.screenCord = new Vector2((orgX + 20), orgY);
                break;
            case 1:
                newPos = SpriteAction.damageRight;
                orgX = castSprite.screenCord.X;
                orgY = castSprite.screenCord.Y;
                castSprite.screenCord = new Vector2((orgX - 20), orgY);
                break;
            case 2:
                newPos = SpriteAction.damageUp;
                orgX = castSprite.screenCord.X;
                orgY = castSprite.screenCord.Y;
                castSprite.screenCord = new Vector2(orgX, (orgY + 20));
                break;
            case 3:
                newPos = SpriteAction.damageDown;
                orgX = castSprite.screenCord.X;
                orgY = castSprite.screenCord.Y;
                castSprite.screenCord = new Vector2(orgX, (orgY -20));
                break;
            default:
                newPos = (SpriteAction)castSprite.spritePos;
                break;

        }
        castSprite.SetSpriteState(newPos, castSprite.damaged);
    }

    public void PauseEnemies()
    {
        pauseEnemies = true;

        //set all enemies to still
        foreach (IConcreteSprite enemy in EnemyList)
        {
            enemy.SetSpriteState(enemyAction, enemy.still);            
        }
    }

    public void UnpauseEnemies()
    {
        pauseEnemies = false;
    }
    private void CheckEnteredDoor()
    {
       
        if(Link != null) {
            IConcreteSprite castedLink = (IConcreteSprite)Link;
            
        //check left door
        if (Link.screenCord.X < (leftDoorBoundary + BaseCord.X) && !castedLink.isDead)
        {
                roomObjectManager.nextRoom("Left");
        } 
        //check right door
        else if(Link.screenCord.X > (rightDoorBoundary + BaseCord.X) && !castedLink.isDead)
        {
                roomObjectManager.nextRoom("Right");
            }
        //check up door
        else  if (Link.screenCord.Y < (upDoorBoundary + BaseCord.Y) && !castedLink.isDead)
        {
                roomObjectManager.nextRoom("Up");
        }

        //check down door
        else if (Link.screenCord.Y > (downDoorBoundary + BaseCord.Y) && !castedLink.isDead)
        {
                roomObjectManager.nextRoom("Down");
        }

       }

    
    }
  }