using System;
using Classes.EventArg;

namespace Classes.Interfaces
{
    public interface IDoor
    {
        event EventHandler<DoorEventArgs> DoorOpenEvent;
        event EventHandler<DoorEventArgs> DoorCloseEvent;

        public void LockDoor();
        public void UnlockDoor();
    }
}
