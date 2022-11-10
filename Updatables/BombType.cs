using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class BombType : IProjectileType
{
    private IProjectile projectile;
    private FireProjectile fireProjectile;
    private bool shouldDraw;
    private int counter;
    private int distance;

    public BombType(IProjectile projectile)
    {
        this.projectile = projectile;
    }

    public void Update(GameTime gameTime)
    {
        fireProjectile = projectile.FireCommand();
        shouldDraw = projectile.ShouldDraw();
        counter = fireProjectile.Counter();
        distance = projectile.Distance();

        if (counter >= distance - 20)
        {
            SoundManager.Instance.PlayOnce("LOZ_Bomb_Blow");
            projectile.SetSpriteAction(SpriteAction.bombCloud);           
        }

        if (shouldDraw)
        {
            fireProjectile.Execute();
        }

        //check for collisions and effects
        //UpdateCollisions(gameTime);
    }

    
    public void UpdateCollisions(GameTime gameTime)
    {
        
        if (shouldDraw && counter >= distance - 20)
        {
            IRoomObject _currentRoom = RoomObjectManager.Instance.currentRoom();
            Vector2 prevCord = projectile.screenCord;
            projectile.SetPosition(new Vector2(prevCord.X - 30, prevCord.Y - 30));
            ISprite collidingObject = projectile.collider.isIntersecting(_currentRoom.ProjectileStopperList);

            collidingObject = projectile.collider.isIntersecting(new List<ISprite> { _currentRoom.Link });
            bool check = projectile.Owner() != _currentRoom.Link;

            if (check && collidingObject != null)
            {
                
                _currentRoom.TakeDamage(collidingObject);
            }

            collidingObject = projectile.collider.isIntersecting(_currentRoom.EnemyList);
            check = !(_currentRoom.EnemyList.Contains(projectile.Owner()));
            check = check && !_currentRoom.DeadEnemyList.Contains(collidingObject);

            if (check && collidingObject != null)
            {
                _currentRoom.KillEnemy(collidingObject);
                DropHandler.Drop(_currentRoom, collidingObject.screenCord);
            }

            //check for bombable doors
            collidingObject = projectile.collider.isIntersecting(_currentRoom.BombDoorsList.Keys);
            check = projectile.Owner() == _currentRoom.Link;

            if (check && collidingObject != null)
            {
                _currentRoom.OpenDoor(collidingObject);
            }

            projectile.SetPosition(prevCord);
        }
        
    }
}


