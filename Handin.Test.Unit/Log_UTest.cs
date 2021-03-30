using System;
using System.IO;
using Classes;
using NUnit.Framework;

namespace Handin.Test.Unit
{
    public class Log_UTest
    {
        private LogFile _logFile;

        [SetUp]
        public void Setup()
        {
            _logFile = new LogFile();
        }

        // Testing log for locked door
        [Test]
        public void Test_DoorLocked_logfileReceivesCorrectString()
        {
            
            string filepath = Directory.GetCurrentDirectory();
            _logFile.LogWhenDoorLock(1);
            string[] lines = File.ReadAllLines(filepath + @"\logfile.txt");

            String Text = lines[^1];
            Assert.That(Text, Is.EqualTo(DateTime.Now + ": Skab låst med RFID: 1"));
        }

        // Testing log for unlocked door
        [Test]
        public void Test_DoorUnlocked_logfileReceivesCorrectString()
        {
            string filepath = Directory.GetCurrentDirectory();
            _logFile.LogWhenDoorUnlock(1);
            string[] lines = File.ReadAllLines(filepath + @"\logfile.txt");

            String Text = lines[^1];
            Assert.That(Text, Is.EqualTo(DateTime.Now + ": Skab låst op med RFID: 1"));
        }

    }
}
