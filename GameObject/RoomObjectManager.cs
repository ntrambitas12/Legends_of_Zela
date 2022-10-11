using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RoomObjectManager : IRoomObjectManager
{
    private ArrayList roomList;
    private IRoomObject _currentRoom;
    public RoomObjectManager()
    {
        roomList = new ArrayList();
    }
    public void addRoom(IRoomObject room)
    {
        roomList.Add(room);
        _currentRoom = room;
    }

    public IRoomObject currentRoom()
    {
        return _currentRoom;
    }

    public void Draw()
    {
        /*In the future, this will draw all the rooms.
         * Camera will be focued only on the current room*/
        _currentRoom.Draw();
    }

    public void Reset()
    {
        foreach (IRoomObject room in roomList)
        {
            room.ResetControllers();
        }
        
    }

    public void setRoom(int roomId)
    {
        _currentRoom = (IRoomObject)roomList[roomId];
    }

    public void Update(GameTime gameTime)
    {
       _currentRoom.Update(gameTime);
    }

    public void DeleteGameObject(int objectType, ISprite gameObject)
    {
        _currentRoom.DeleteGameObject(objectType, gameObject);
    }
}

