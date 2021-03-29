using Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbSimulator;

namespace Classes
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        private IChargeControl _charger;
        private int _oldId;
        private IDoor _door;
        private IRFIDReader _rfidReader;
        private ILog _log;
        private IDisplay _display;

        // Her mangler constructor
        public StationControl(IDoor door, IChargeControl charger, IRFIDReader rfid, IDisplay display, ILog log)
        {
            _state = LadeskabState.Available;
            _door = door;
            _charger = charger;
            _rfidReader = rfid;
            _display = display;
            _log = log;

            _rfidReader.RFIDReadEvent += RfidDetected;
            _door.DoorOpenEvent += OnDoorOpen;
            _door.DoorCloseEvent += OnDoorClose;
        }


        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        private void RfidDetected(object sender, EventArg.RFIDEventArgs e)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_charger.IsConnected())
                    {
                        _door.LockDoor();
                        _charger.StartCharge();
                        _oldId = e.id;
                        

                        _display.DisplayMsg(MessageType.ChargeStationInUse);
                        _display.DisplayMsg(MessageType.PhoneCharging);
                        _display.DisplayMsg(MessageType.RfidRead);
                        //Console.WriteLine("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
                        _state = LadeskabState.Locked;
                        _log.LogWhenDoorLock(e.id);
                    }
                    else
                    {
                        _display.DisplayMsg(MessageType.ConnectionError);
                        //Console.WriteLine("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (e.id == _oldId)
                    {
                        _charger.StopCharge();
                        _door.UnlockDoor();
                        _log.LogWhenDoorUnlock(e.id);

                        _display.DisplayMsg(MessageType.DisconnectPhone);
                        //Console.WriteLine("Tag din telefon ud af skabet og luk døren");
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        _display.DisplayMsg(MessageType.RfidWrong);
                        //Console.WriteLine("Forkert RFID tag");
                    }

                    break;
            }
        }

        // Her mangler de andre trigger handlere
        public void OnDoorOpen(object sender, EventArg.DoorEventArgs e)
        {
            _state = LadeskabState.DoorOpen;
            _display.DisplayMsg(MessageType.ConnectPhone);
        }

        public void OnDoorClose(object sender, EventArg.DoorEventArgs e)
        {
            _state = LadeskabState.Available;
            _display.DisplayMsg(MessageType.RfidRead);
        }
    }
}
