using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class DoorSimulator : IDoor
    {

        public bool DoorLocked { get; set; }

        public bool IsDoorOpen { get; set; }

        public void LockDoor()
        {
            DoorLocked = false;
            Console.WriteLine("Door is locked...");
        }

        public void UnlockDoor()
        {
            DoorLocked = true; 
            Console.WriteLine("Door is unlocked...");
        }

        public void OpenDoor()
        {
            if (DoorLocked == false)
            {
                IsDoorOpen = true;
            }
        }

        public void CloseDoor()
        {
            if (DoorLocked == true)
            {
                IsDoorOpen = false;
            }
        }

    }
}
