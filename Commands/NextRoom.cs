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
                if (nextRoomID < room.numberOfRooms())
                {
                    room.setRoom(nextRoomID, true);
                }
            }
        }
    }
}

