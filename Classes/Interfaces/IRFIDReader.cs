using System;
using Classes.EventArg;

namespace Classes.Interfaces
{
    public interface IRFIDReader
    {
        event EventHandler<RFIDEventArgs> RFIDReadEvent;
    }
}
