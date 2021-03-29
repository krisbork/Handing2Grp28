using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
