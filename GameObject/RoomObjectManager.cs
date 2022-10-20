using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public sealed class RoomObjectManager : IRoomObjectManager
{
    private ArrayList roomList;
    private IRoomObject _currentRoom;
    private RoomObjectManager()
    {
        roomList = new ArrayList();
    }

    private static readonly RoomObjectManager instance = new RoomObjectManager();
    public static RoomObjectManager Instance { get { return instance; } }

    public void addRoom(IRoomObject room)
    {
        roomList.Add(room);
        if (_currentRoom == null)
        {
            _currentRoom = room;
        }
    }

    public IRoomObject currentRoom()
    {
        return _currentRoom;
    }

    public void Draw(GameTime gameTime)
    {
        /*In the future, this will draw all the rooms.
         * Camera will be focued only on the current room*/
        _currentRoom.Draw(gameTime);
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
        var Link = _currentRoom.Link;
        _currentRoom.Link = null;
        _currentRoom = (IRoomObject)roomList[roomId];
        _currentRoom.Link = Link;
        
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