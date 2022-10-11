using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

    public interface IRoomObjectManager
    {
    
    public void addRoom(IRoomObject room);
    public void setRoom(int roomId);
    public IRoomObject currentRoom();
    public void Reset();
    public void Draw();
    public void Update();
    public void DeleteGameObject(int objectType, ISprite gameObject);
}

