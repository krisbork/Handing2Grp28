using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using NUnit.Framework;

namespace Handin.Test.Unit
{
    public class DoorTest
    {
        private DoorSimulator door;

        public int numberOfEvents { get; set; }

        [SetUp]
        public void Setup()
        {
            door = new DoorSimulator();
            numberOfEvents = 0;
            door.DoorOpenEvent += Door_OpenEvent;
            door.DoorCloseEvent += Door_CloseEvent;
        }

        private void Door_OpenEvent(object sender, Classes.EventArg.DoorEventArgs e)
        {
            numberOfEvents++;
        }
        private void Door_CloseEvent(object sender, Classes.EventArg.DoorEventArgs e)
        {
            numberOfEvents++;
        }

        [Test]
        /* Testing: DoorOpen when locked/unlocked and event trigger */

        public void Test_OpenDoor_WhileLocked_DoorOpens()
        {
            door.LockDoor();
            door.OpenDoor();
            Assert.That(door.IsDoorOpen, Is.EqualTo(false));
        }

        public void Test_OpenDoor_WhileUnlocked_DoorOpens()
        {
            door.UnlockDoor();
            door.OpenDoor();
            Assert.That(door.IsDoorOpen, Is.EqualTo(true));
        }

        public void Test_

    }
}
