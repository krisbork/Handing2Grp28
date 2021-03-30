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
        ChargeError,
        ChargeStationInUse
    };
    public interface IDisplay
    {
        public void DisplayMsg(MessageType type);
    }
}
