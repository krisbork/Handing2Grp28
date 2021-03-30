using System;
using System.IO;
using Classes.Interfaces;

namespace Classes
{
    public class LogFile: ILog
    {
        private readonly string _logFile = "logfile.txt";
        public LogFile()
        {
        }

        public void LogWhenDoorLock(int id)
        {
            using var writer = File.AppendText(_logFile);
            writer.WriteLine(DateTime.Now + ": Skab låst med RFID: {0}", id);
        }

        public void LogWhenDoorUnlock(int id)
        {
            using var writer = File.AppendText(_logFile);
            writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", id);
        }
    }
}
