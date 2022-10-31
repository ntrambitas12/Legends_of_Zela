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
    private ICollisionManager collisionManager;

    private RoomObjectManager()
    {
        roomList = new ArrayList();
        collisionManager = CollisionManager.Instance;
    }

    private static RoomObjectManager instance = new RoomObjectManager();
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

    public int currentRoomID()
    {
        return roomList.IndexOf(_currentRoom);
    }

    public int numberOfRooms()
    {
        return roomList.Capacity - 1;
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
        instance = new RoomObjectManager();

    }

    public void setRoom(int roomId)
    {
        if (roomId < roomList.Count)
        {
            var Link = _currentRoom.Link;
            _currentRoom.Link = null;
            _currentRoom = (IRoomObject)roomList[roomId];
            _currentRoom.Link = Link;
        }
    }

    public void nextRoomRight()
    {
        _currentRoom.UnpauseEnemies();
        var Link = _currentRoom.Link;
        _currentRoom.Link = null;
        int roomNum = this.currentRoomID();
        this.setRoom(roomNum + 1);
        _currentRoom = Instance._currentRoom;
        _currentRoom.Link = Link;
        Vector2 newPos = new Vector2(0, 240);  // might have to adjust these coordinates slightly
        _currentRoom.Link.screenCord = newPos;
    }

    public void nextRoomLeft()
    {
        _currentRoom.UnpauseEnemies();
        var Link = _currentRoom.Link;
        _currentRoom.Link = null;
        int roomNum = this.currentRoomID();
        this.setRoom(roomNum - 1);
        _currentRoom = Instance._currentRoom;
        _currentRoom.Link = Link;
        Vector2 newPos = new Vector2(800, 240); // might have to adjust these coordinates slightly
        _currentRoom.Link.screenCord = newPos;
    }

    public void nextRoomUp()
    {
        _currentRoom.UnpauseEnemies();
        var Link = _currentRoom.Link;
        _currentRoom.Link = null;
        int roomNum = this.currentRoomID();
        this.setRoom(roomNum - 6);
        _currentRoom = Instance._currentRoom;
        _currentRoom.Link = Link;
        Vector2 newPos = new Vector2(400, 480); // might have to adjust these coordinates slightly
        _currentRoom.Link.screenCord = newPos;
    }

    public void nextRoomDown()
    {
        _currentRoom.UnpauseEnemies();
        var Link = _currentRoom.Link;
        _currentRoom.Link = null;
        int roomNum = this.currentRoomID();
        this.setRoom(roomNum + 6);
        _currentRoom = Instance._currentRoom;
        _currentRoom.Link = Link;
        Vector2 newPos = new Vector2(400, 0); // might have to adjust these coordinates slightly
        _currentRoom.Link.screenCord = newPos;
    }

    public void Update(GameTime gameTime)
    {
        _currentRoom.Update(gameTime);
        collisionManager.Update(gameTime);
    }

    public void DeleteGameObject(int objectType, ISprite gameObject)
    {
        _currentRoom.DeleteGameObject(objectType, gameObject);
    }
}