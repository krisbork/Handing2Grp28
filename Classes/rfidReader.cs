using System;
using Classes.EventArg;
using Classes.Interfaces;

namespace Classes
{
    public class rfidReader : IRFIDReader
    {
        public event EventHandler<RFIDEventArgs> RFIDReadEvent;

        public void ScanRFID(int _id)
        {
            OnRfidRead(new RFIDEventArgs {id = _id});
        }

        protected virtual void OnRfidRead(RFIDEventArgs e)
        {
            RFIDReadEvent?.Invoke(this, e);
        }
    }
}
