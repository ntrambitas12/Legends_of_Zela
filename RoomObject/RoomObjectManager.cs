using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public sealed class RoomObjectManager : IRoomObjectManager
{
    private  IRoomObject[] roomList;
    private IRoomObject _currentRoom;
    private Camera camera;
    private Dictionary<String, (int, int, int)> roomDir;
    private RoomObjectManager()
    {
        roomList = new IRoomObject[100];
        camera = Camera.Instance;
        roomDir = new Dictionary<String, (int, int, int)>();
        roomDir.Add("Up", (400, 430, 5));
        roomDir.Add("Down", (400, 112, -5));
        roomDir.Add("Left", (620, 240, -1));
        roomDir.Add("Right", (150, 240, 1));


    }

    private static RoomObjectManager instance = new RoomObjectManager();
    public static RoomObjectManager Instance { get { return instance; } }

    public void addRoom(IRoomObject room, int id)
    {
        roomList[id] = room;
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
        int ret = Array.IndexOf(roomList, _currentRoom);
        return ret;
    }

    public int numberOfRooms()
    {
        return roomList.Length - 1;
    }

    public void Draw(GameTime gameTime)
    {
       //foreach (IRoomObject room in roomList)
       // {
            _currentRoom.Draw(gameTime);
      //  }
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
        if (roomId < roomList.Length)
        {
            var Link = _currentRoom.Link;
            Vector2 LinkCord = Link.screenCord - _currentRoom.BaseCord;
            _currentRoom.Link = null;
            _currentRoom = roomList[roomId];
            while (_currentRoom == null)
            {
                roomId++;
                if(roomId < roomList.Length)
                _currentRoom = roomList[roomId];
            }
            Vector2 baseCord = _currentRoom.BaseCord;
            _currentRoom.Link = Link;
            //move the camera to the right room
            camera.Move(baseCord);
            //update link's cordinates
            _currentRoom.Link.screenCord = baseCord + LinkCord;
        }
    }


    public void nextRoom(String direction)
    {
        
            roomDir.TryGetValue(direction, out var roomData);
            var Link = _currentRoom.Link;
            Vector2 LinkCord = new Vector2(roomData.Item1, roomData.Item2);
            _currentRoom.Link = null;
            _currentRoom = roomList[currentRoomID() + roomData.Item3];
            _currentRoom.Link = Link;
            Vector2 baseCord = _currentRoom.BaseCord;
            camera.Move(baseCord);
            _currentRoom.Link.screenCord = LinkCord + baseCord;
        

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