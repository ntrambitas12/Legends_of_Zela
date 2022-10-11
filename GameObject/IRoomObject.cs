using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//used for specifying which list to add/remove
public enum RoomObjectTypes
{
    typeController = -1,
    typeLink = 0,
    typeLinkProjectile = 1,
    typeEnemy = 2,
    typeEnemyProjectile = 3,
    typeTileStatic = 4,
    typeTileDynamic = 5,
    typePickup = 6,
    typeCollisionBox = 7,
    typeTopLayerNonCollidible = 8,
}

//handles lists for all game objects of all types.
//ONLY GAME OBJECTS THAT ARE DRAWN AND/OR UPDATED ARE IN THESE LISTS.
//  this should include ONLY the game objects in the CURRENT room.
public interface IRoomObject
{
    //the controllers list
    //includes keyboardController, mouseController, gamepadController(?)
    public List<IController> ControllerList { get; set; }

    //the pointer for Link
    public ISprite Link { get; set; }

    //list for all projectiles
    public List<ISprite> LinkProjectileList { get; set; }

    //the list for enemies
    public List<ISprite> EnemyList { get; set; }

    //list for enemy projectiles
    public List<ISprite> EnemyProjectileList { get; set; }

    //list for static tiles
    public List<ISprite> StaticTileList { get; set; }

    //list for dynamic tiles (doors, moving tiles)
    public List<ISprite> DynamicTileList { get; set; }

    //list for item pickups
    public List<ISprite> PickupList { get; set; }

    //list for things that stop entity movement
    //note that this list also contains ALL TILES in, addition to invisible collision boxes
    public List<ISprite> CollidibleList { get; set; }

    //list for non-collidible sprites and tiles (top of doorways etc.)
    //Link and enemies will disappear under these
    public List<ISprite> TopLayerNonCollidibleList { get; set; }

    //adds gameObject into its lists
    //which list depends on the enum passed as objectType
    public void AddGameObject(int objectType, ISprite gameObject);

    //adds controllers to the list
    public void AddController(IController controller);

    //adds objectType and gameObject into the private toBeDeleted list.
    //toBeDeleted is processed at the end of the this class's Update() method.
    //toBeDeleted list is declared as:
    //  private List<(ISprite, int)> toBeDeleted;
    public void DeleteGameObject(int objectType, ISprite gameObject);

    //is called by the Game class, Game1, in its Update() method.
    //updates all Updateables, includes
    //  controllers
    //  Link
    //  enemies
    //  projectiles (both types)
    //  pickup items
    //  dynamic tiles
    //after updating game objects, goes into 'delete step', and deletes game objects held in private toBeDeleted list
    //clears toBeDeleted once all objects in it have been deleted from Game Object's various lists
    public void Update(GameTime gameTime);

    //is called by the Game class, Game1, in its Draw() method.
    //draws all drawables IN THIS SPECIFIC ORDER, includes
    //  background
    //  tiles (both types)
    //  projectiles (both types)
    //  pickup items
    //  enemies
    //  link
    //  top of doorways (so that it is on the top-most layer and Link disappears below it)
    public void Draw();

    public void ResetControllers();
}