using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

    public interface IRoomObjectManager
    {
    
    public void addRoom(IRoomObject room, int id);
    public void setRoom(int roomId, bool inc);
    public IRoomObject getRoom(int roomId);
    public IRoomObject[] getRooms();
    public IRoomObject currentRoom();
    public int currentRoomIdx();
    public IRoomObject adjacentRoom(SpriteAction direction);
    public void Reset();
    public void Draw(GameTime gameTime);
    public void Update(GameTime gameTime);
    public void DeleteGameObject(int objectType, ISprite gameObject);
}

