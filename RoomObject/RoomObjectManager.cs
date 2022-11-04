using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public sealed class RoomObjectManager : IRoomObjectManager
{
    private  IRoomObject[] roomList;
    private IRoomObject _currentRoom;
    private bool isTransitioning;
    private Camera camera;
    private String direction;
    private int roomXLimit = 400;
    private int roomYLimit = 250;
    private Vector2 RightPan;
    private Vector2 LeftPan;
    private Vector2 UpPan;
    private Vector2 DownPan;
    private Dictionary<String, (int, int, int, Vector2, int, bool)> roomDir;
  
    private ICollisionManager collisionManager;

    private RoomObjectManager()
    {
        roomList = new IRoomObject[100];
        camera = Camera.Instance;
        roomDir = new Dictionary<String, (int, int, int, Vector2, int, bool)>();
        RightPan = new Vector2(25, 0);
        LeftPan = new Vector2(-25, 0);
        UpPan = new Vector2(0, -20);
        DownPan = new Vector2(0, 20);
        roomDir.Add("Up", (400, 430, 5, UpPan, roomYLimit, false));
        roomDir.Add("Down", (400, 112, -5, DownPan, roomYLimit, false));
        roomDir.Add("Left", (620, 240, -1, LeftPan, roomXLimit, true));
        roomDir.Add("Right", (150, 240, 1, RightPan, roomXLimit, true));
        isTransitioning = false;

        collisionManager = CollisionManager.Instance;
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
        if(ret == -1)
        {
            ret = 0;
        }
        return ret;
    }

    public int numberOfRooms()
    {
        return roomList.Length - 1;
    }

    public void Draw(GameTime gameTime)
    {
        foreach (var room in roomList)
        {
            if (room != null)
            {
                room.Draw(gameTime);
            }
        }
    }

    public void Reset()
    {
        foreach (IRoomObject room in roomList)
        {
            if (room != null)
            {
                room.ResetControllers();
            }
        }
        instance = new RoomObjectManager();

    }

    public void setRoom(int roomId, bool inc)
    {
        if (roomId < roomList.Length-1 && roomId >= 0)
        {
            var Link = _currentRoom.Link;
            Vector2 LinkCord = Link.screenCord - _currentRoom.BaseCord;
            _currentRoom.Link = null;
            _currentRoom = roomList[roomId];

            //find the next not null element in the room array
            while (_currentRoom == null)
            {
                //either decrement or increment till the next room
                if (inc)
                {
                    roomId++;
                } else
                {
                    roomId--;
                }


                if (roomId < roomList.Length - 1 && roomId >= 0) {
                    _currentRoom = roomList[roomId];
                }
                else
                {
                    //loop back to 0 if we reach the end of the array
                    roomId = 0;
                }
            }
            Vector2 baseCord = _currentRoom.BaseCord;
            _currentRoom.Link = Link;
            //move the camera to the right room
            camera.Set(baseCord);
            //update link's cordinates
            _currentRoom.Link.screenCord = baseCord + LinkCord;
        }
    }

    public IRoomObject adjacentRoom(SpriteAction direction)
    {
        switch (direction)
        {
            case SpriteAction.left:
                return roomList[currentRoomID() - 1];
            case SpriteAction.right:
                return roomList[currentRoomID() + 1];
            case SpriteAction.up:
                return roomList[currentRoomID() + 5];
            case SpriteAction.down:
                return roomList[currentRoomID() - 5];
            default:
                break;
        }
        return null;
    }


    public void nextRoom(String direction)
    {
        this.direction = direction; 
        roomDir.TryGetValue(direction, out var roomData);
        var Link = _currentRoom.Link;
        _currentRoom.UnpauseEnemies();
        Vector2 LinkCord = new Vector2(roomData.Item1, roomData.Item2);
        _currentRoom.Link = null;
        //move link to the next room and enter the transition state
        _currentRoom = roomList[currentRoomID() + roomData.Item3];
        _currentRoom.Link = Link;
        _currentRoom.Link.screenCord = LinkCord + _currentRoom.BaseCord;
        isTransitioning = true;
    }

    private void panRoom()
    {
        roomDir.TryGetValue(direction, out var roomData);
        //if we are checking the X condition:
        if(roomData.Item6)
        {
            camera.Move(roomData.Item4);
            if (camera.pos.X == _currentRoom.BaseCord.X + roomData.Item5)
            {
                isTransitioning = false;
            }
        } 
        //check the y condition
        else
        {
            camera.Move(roomData.Item4);
            if (camera.pos.Y == _currentRoom.BaseCord.Y + roomData.Item5)
            {
                isTransitioning = false;
            }
        }
        
    }


    public void Update(GameTime gameTime)
    {
        _currentRoom.Update(gameTime);
        if (isTransitioning)
        {
            panRoom();
        }
        collisionManager.Update(gameTime);
    }

    public void DeleteGameObject(int objectType, ISprite gameObject)
    {
        _currentRoom.DeleteGameObject(objectType, gameObject);
    }
}