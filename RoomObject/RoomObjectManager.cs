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
    private Camera camera;
    private Dictionary<String, (int, int, int, int, int)> roomDir;
    private RoomObjectManager()
    {
        roomList = new ArrayList();
        camera = Camera.Instance;
        roomDir = new Dictionary<String, (int, int, int, int, int)>();
        roomDir.Add("Up", (400, 480, -6, 0, 150));
        roomDir.Add("Down", (400, 0, 6, 0, -150));
        roomDir.Add("Left", (800, 240, -1, -150, 0));
        roomDir.Add("Right", (0, 240, 1, 150, 0));


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


    public void nextRoom(String direction)
    {
        roomDir.TryGetValue(direction, out var roomData);
        var Link = _currentRoom.Link;
        _currentRoom.Link = null;
        setRoom(currentRoomID() + roomData.Item3);
        _currentRoom.Link = Link;
        Vector2 newPos = new Vector2(roomData.Item1, roomData.Item2); 
        camera.Move(new Vector2((float)roomData.Item4, (float)roomData.Item5));
        _currentRoom.Link.screenCord = newPos;

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