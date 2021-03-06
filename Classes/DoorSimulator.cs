using System;
using Classes.EventArg;
using Classes.Interfaces;

namespace Classes
{
    public class DoorSimulator : IDoor
    {

        public bool DoorLocked { get; set; }

        public bool IsDoorOpen { get; set; }

        public void LockDoor()
        {
            DoorLocked = true;
            Console.WriteLine("Door is locked...");
        }

        public void UnlockDoor()
        {
            DoorLocked = false; 
            Console.WriteLine("Door is unlocked...");
        }

        public event EventHandler<DoorEventArgs> DoorOpenEvent;
        public event EventHandler<DoorEventArgs> DoorCloseEvent;

        protected virtual void WhenDoorClose(DoorEventArgs e)
        {
            DoorCloseEvent?.Invoke(this, e);
        }

        protected virtual void WhenDoorOpen(DoorEventArgs e)
        {
            DoorOpenEvent?.Invoke(this, e);
        }

        public void OpenDoor()
        {
            if (DoorLocked != true)
            {
                IsDoorOpen = true;
                WhenDoorOpen(new DoorEventArgs { });
            }
        }

        public void CloseDoor()
        {
            if (DoorLocked != true)
            {
                IsDoorOpen = false;
                WhenDoorClose(new DoorEventArgs { });
            }
        }

    }
}
