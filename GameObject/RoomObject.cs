using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        listDict.Add((int)RoomObjectTypes.typeEnemyProjectile, EnemyProjectileList);
        listDict.Add((int)RoomObjectTypes.typeTileStatic, StaticTileList);
        listDict.Add((int)RoomObjectTypes.typeTileDynamic, DynamicTileList);
        listDict.Add((int)RoomObjectTypes.typePickup, PickupList);
        listDict.Add((int)RoomObjectTypes.typeCollisionBox, CollidibleList);
        listDict.Add((int)RoomObjectTypes.typeTopLayerNonCollidible, TopLayerNonCollidibleList);


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

    public void Update()
    {
        //update all controllers
        foreach(var controller in ControllerList)
        {
            controller.Update();
        }

        Link.Update();

        //update all enemies
        foreach(var enemy in EnemyList)
        {
            enemy.Update();
        }

        //update projectiles
        foreach(var linkProjectile in LinkProjectileList)
        {
            linkProjectile.Update();
        }

        foreach(var enemyProjectile in EnemyProjectileList)
        {
            enemyProjectile.Update();
        }

        //update pickup items
        foreach(var item in PickupList)
        {
            item.Update();
        }

        //update dynamic tiles
        foreach(var tile in DynamicTileList)
        {
            tile.Update();
        }

        Delete();
    }

    public void Draw()
    {
        //  background
        /* ADD CODE HERE ONCE BACKGROUND EXISTS*/

        foreach (var controller in ControllerList)
        {
            controller.Draw();
        }
        //  tiles (both types)
        foreach (var tile in DynamicTileList)
        {
            tile.Draw();
        }

        foreach (var tile in StaticTileList)
        {
            tile.Draw();
        }
        //  projectiles (both types)
        foreach (var linkProjectile in LinkProjectileList)
        {
            linkProjectile.Draw();
        }

        foreach (var enemyProjectile in EnemyProjectileList)
        {
            enemyProjectile.Draw();
        }
        //  pickup items
        foreach (var item in PickupList)
        {
            item.Draw();
        }
        //  enemies
        foreach (var enemy in EnemyList)
        {
            enemy.Draw();
        }
        //  link
        Link.Draw();
        //  top of doorways (so that it is on the top-most layer and Link disappears below it)
        foreach (var item in TopLayerNonCollidibleList)
        {
            item.Draw();
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

