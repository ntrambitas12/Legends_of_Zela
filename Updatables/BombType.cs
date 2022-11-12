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
    private float timeElapsed;

    public BombType(IProjectile projectile)
    {
        this.projectile = projectile;
        timeElapsed = 0;
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
        timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    
    public void UpdateCollisions(GameTime gameTime)
    {
        
        if (shouldDraw && counter >= distance - 20 && projectile.ShouldCollide())
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

            if (check && collidingObject != null && timeElapsed > .1)
            {
                ((IConcreteSprite)collidingObject).health--;
                projectile.SetShouldCollide(false);
                if (((IConcreteSprite)collidingObject).health == 0)
                {
                    _currentRoom.KillEnemy(collidingObject);
                    DropHandler.Drop(_currentRoom, collidingObject.screenCord);
                }
                timeElapsed = 0;
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


