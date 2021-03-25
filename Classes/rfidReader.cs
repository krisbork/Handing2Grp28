using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.EventArg;

namespace Classes
{
    public class rfidReader : IRFIDReader
    {
        public event EventHandler<RFIDEventArgs> RFIDReadEvent;

        public void ScanRFID(string _id)
        {
            OnScanRFID(new RFIDEventArgs {id = _id});
        }

        protected virtual void OnScanRFID(RFIDEventArgs e)
        {
            RFIDReadEvent?.Invoke(this, e);
        }
    }
}
