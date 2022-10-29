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
    private IRoomObject _previousRoom;
    private bool isTransitioning;
    private Camera camera;
    private String direction;
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
        isTransitioning = false;


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
        _currentRoom.Draw(gameTime);

        if (_previousRoom != null && isTransitioning)
        {
            _previousRoom.Draw(gameTime);
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

    public void setRoom(int roomId)
    {
        /*TODO: test this  */
        if (roomId < roomList.Length)
        {
            var Link = _currentRoom.Link;
            Vector2 LinkCord = Link.screenCord - _currentRoom.BaseCord;
            _currentRoom.Link = null;
            _previousRoom = _currentRoom;
            _currentRoom = roomList[roomId];
            while (_currentRoom == null)
            {
                roomId++;
                if (roomId < roomList.Length)
                _currentRoom = roomList[roomId];
            }
            Vector2 baseCord = _currentRoom.BaseCord;
            _currentRoom.Link = Link;
            //move the camera to the right room
            camera.Set(baseCord);
            //update link's cordinates
            _currentRoom.Link.screenCord = baseCord + LinkCord;
        }
    }


    public void nextRoom(String direction)
    {
        this.direction = direction; 
            roomDir.TryGetValue(direction, out var roomData);
            var Link = _currentRoom.Link;
            Vector2 LinkCord = new Vector2(roomData.Item1, roomData.Item2);
              _previousRoom = _currentRoom;
              _currentRoom.Link = null;
             int nextRoom = currentRoomID() + roomData.Item3;
               if (nextRoom >= 0 && nextRoom < roomList.Length)
             {
            _currentRoom = roomList[nextRoom];
             } 
           _currentRoom.Link = Link;
        Vector2 baseCord = _currentRoom.BaseCord;
        _currentRoom.Link.screenCord = LinkCord + baseCord;
        isTransitioning = true;
          
        
            
        
        

    }

    private void panRoom()
    {
        /* Since were checking against X and Y, we need to do some sort
         * of branching. Since there's only 4 directions, this seems to be 
         * an acceptable location for switch case*/

        switch (direction) {
            case "Right":
        
            camera.Move(new Vector2(25, 0));
            if (camera.pos.X == _currentRoom.BaseCord.X + 400)
            {
                isTransitioning = false;
            }
                break;
            case "Left":
        
            camera.Move(new Vector2(-25, 0));
            if (camera.pos.X == _currentRoom.BaseCord.X + 400)
            {
                isTransitioning = false;
            }
                break;

            case "Up":
            camera.Move(new Vector2(0, 20));
            if (camera.pos.Y == _currentRoom.BaseCord.Y + 250)
            {
                isTransitioning = false;
            }
                    break;

            case "Down":
            camera.Move(new Vector2(0, -20));
            if (camera.pos.Y == _currentRoom.BaseCord.Y + 250)
            {
                isTransitioning = false;
            }
                break;
    }

    }


    public void Update(GameTime gameTime)
    {
        _currentRoom.Update(gameTime);
        if (isTransitioning)
        {
            panRoom();
        }
    }

    public void DeleteGameObject(int objectType, ISprite gameObject)
    {
        _currentRoom.DeleteGameObject(objectType, gameObject);
    }
}