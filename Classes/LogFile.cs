using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Interfaces;

namespace Classes
{
    public class LogFile: ILog
    {
        private TextWriter writer;
        public LogFile(string logFile)
        {
            var writer = File.AppendText(logFile);
        }

        public void LogWhenDoorLock(int id)
        {
            writer.WriteLine(DateTime.Now + ": Skab låst med RFID: {0}", id);
        }

        public void LogWhenDoorUnlock(int id)
        {
            writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", id);
        }
    }
}
