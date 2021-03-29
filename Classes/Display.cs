using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Interfaces;

namespace Classes
{
    public class Display : IDisplay
    {
        public void DisplayMsg(MessageType type)
        {
            switch (type)
            {
                case MessageType.RfidRead:
                    Console.WriteLine("Put RFID tag in front of reader to unlock.");
                    break;
                case MessageType.RfidError:
                    Console.WriteLine("Error reading RFID tag.");
                    break;
                case MessageType.RfidWrong:
                    Console.WriteLine("Wrong RFID tag.");
                    break;
                case MessageType.PhoneFullyCharged:
                    Console.WriteLine("Phone is fully charged.");
                    break;
                case MessageType.ChargeError:
                    Console.WriteLine("Error occurred while charging.");
                    break;
                case MessageType.PhoneCharging:
                    Console.WriteLine("Phone is charging.");
                    break;
                case MessageType.DisconnectPhone:
                    Console.WriteLine("Please disconnect phone.");
                    break;
                case MessageType.ConnectionError:
                    Console.WriteLine("Error connecting to phone.");
                    break;
                case MessageType.ConnectPhone:
                    Console.WriteLine("Please connect phone.");
                    break;
                case MessageType.ChargeStationInUse:
                    Console.WriteLine("Charging station in use.");
                    break;
                default:
                    break;
            }
        }
    }
}
