using System;
namespace CSE3902Project
{
    public class PreviousRoom : ICommand
    {
        private Game1 game;
        private RoomObjectManager room;
        public PreviousRoom(Game1 game, RoomObjectManager room)
        {
            this.game = game;
            this.room = room;
        }
        public void Execute()
        {
            if (room != null)
            {
                int initialRoomID = room.currentRoomID();
                int nextRoomID = room.currentRoomID() - 1;
                if (nextRoomID >= 0)
                {
                    room.setRoom(nextRoomID);
                }
                //    while (room.currentRoom == null)
                //    {
                //        nextRoomID--;
                //        room.setRoom(nextRoomID);
                //        if (nextRoomID < 0)
                //        {
                //            room.setRoom(initialRoomID);
                //            break;
                //        }
                //    }
                //}
            }
        }
    }
}

