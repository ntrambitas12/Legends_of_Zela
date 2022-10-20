using System;
namespace CSE3902Project
{
    public class NextRoom : ICommand
    {
        private Game1 game;
        private RoomObjectManager room;
        public NextRoom(Game1 game, RoomObjectManager room)
        {
            this.game = game;
            this.room = room;
        }
        public void Execute()
        {
            if (room != null)
            {
                int initialRoomID = room.currentRoomID();
                int nextRoomID = room.currentRoomID() + 1;
                room.setRoom(nextRoomID);
                while (room.currentRoom == null)
                {
                    nextRoomID++;
                    room.setRoom(nextRoomID);
                    if (nextRoomID >= 36)
                    {
                        room.setRoom(initialRoomID);
                        break;
                    }
                }
            }
        }
    }
}

