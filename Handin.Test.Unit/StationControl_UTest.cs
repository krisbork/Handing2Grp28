using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Classes;
using Classes.EventArg;
using Classes.Interfaces;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using NSubstitute;
using UsbSimulator;

namespace Handin.Test.Unit
{
    public class StationControl_UTest
    {
        private StationControl _station;
        private IRFIDReader _rfidReader;
        private IDisplay _display;
        private IChargeControl _chargeControl;
        private ILog _log;
        private IDoor _door;
        private IUsbCharger _charger;

        [SetUp]
        public void Setup()
        {
            _rfidReader = Substitute.For<IRFIDReader>();
            _display = Substitute.For<IDisplay>();
            _charger = Substitute.For<IUsbCharger>();
            _chargeControl = Substitute.For<IChargeControl>();
            _log = Substitute.For<ILog>();
            _door = Substitute.For<IDoor>();

            _station = new StationControl(_door, _chargeControl, _rfidReader, _display, _log);
        }

        [Test]
        public void Test_DisplaysWhenDoorOpens()
        {
            _door.DoorOpenEvent += Raise.EventWith(null, new DoorEventArgs());
            _display.Received(1).DisplayMsg(MessageType.ConnectPhone);
        }

            [Test]
        public void Test_DoorBeingLocked()
        {
            _chargeControl.IsConnected().Returns(true);
            _door.DoorCloseEvent += Raise.EventWith(null, new DoorEventArgs());
            _rfidReader.RFIDReadEvent += Raise.EventWith(null, new RFIDEventArgs() {id = 3});
            _door.Received(1).LockDoor();
        }

        [Test]
        public void Test_DisplaysWhenPhoneIsPluggedIn()
        {
            _chargeControl.IsConnected().Returns(true);
            _door.DoorCloseEvent += Raise.EventWith(null, new DoorEventArgs());
            _rfidReader.RFIDReadEvent += Raise.EventWith(null, new RFIDEventArgs() {id = 3});
            _display.Received(3);
        }

        [Test]
        public void Test_DisplaysWhenRFIDEventIsCalled()
        {
            _door.DoorCloseEvent += Raise.EventWith(null, new DoorEventArgs());
            _rfidReader.RFIDReadEvent += Raise.EventWith(null, new RFIDEventArgs() {id = 3});
            _display.Received(1).DisplayMsg(MessageType.ConnectionError);
        }
    }
}
