using System;
using Classes;
using Classes.Interfaces;
using UsbSimulator;

class Program
    {
        static void Main(string[] args)
        {
            // Assemble your system here from all the classes

            IUsbCharger charger = new UsbChargerSimulator();
            DoorSimulator door = new DoorSimulator();
            rfidReader rfid = new rfidReader();
            IDisplay display = new Display();
            ILog log = new LogFile();
            ChargeControl chargeControl = new ChargeControl(charger, display);

            StationControl station = new StationControl(door, chargeControl, rfid, display, log);

            bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("Indtast E, O, C, R, T: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'E':
                        finish = true;
                        break;

                    case 'O':
                        door.OpenDoor();
                        break;

                    case 'C':
                        door.CloseDoor();
                        break;

                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();

                        int id = Convert.ToInt32(idString);
                        rfid.ScanRFID(id);
                        break;

                    case 'T':
                        chargeControl.IsConnectedToggle();
                        break;

                    default:
                        break;
                }

            } while (!finish);
        }
    }
