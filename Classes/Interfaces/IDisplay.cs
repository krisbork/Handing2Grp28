using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Interfaces
{
    public enum MessageType
    {
        RfidRead,
        RfidError,
        RfidWrong,
        ConnectPhone,
        DisconnectPhone,
        ConnectionError,
        PhoneFullyCharged,
        PhoneCharging,
        PhoneError,
        ChargeStationInUse
    };
    public interface IDisplay
    {
        public void DisplayMsg(MessageType type);
    }
}
