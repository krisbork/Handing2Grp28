using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Interfaces
{
    public interface ILog
    {
        public void LogWhenDoorLock(int id);
        public void LogWhenDoorUnlock(int id);
    }
}
