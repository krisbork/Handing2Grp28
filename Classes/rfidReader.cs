using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.EventArg;
using Classes.Interfaces;

namespace Classes
{
    public class rfidReader : IRFIDReader
    {
        public event EventHandler<RFIDEventArgs> RFIDReadEvent;

        public void ScanRFID(string _id)
        {
            OnRfidRead(new RFIDEventArgs {id = _id});
        }

        protected virtual void OnRfidRead(RFIDEventArgs e)
        {
            RFIDReadEvent?.Invoke(this, e);
        }
    }
}
