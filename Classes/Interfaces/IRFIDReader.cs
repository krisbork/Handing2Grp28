﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.EventArg;

namespace Classes.Interfaces
{
    public interface IRFIDReader
    {
        event EventHandler<RFIDEventArgs> RFIDReadEvent;
    }
}