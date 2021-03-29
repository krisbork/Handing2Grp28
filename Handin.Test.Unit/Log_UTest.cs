using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using NUnit.Framework;

namespace Handin.Test.Unit
{
    public class Log_UTest
    {
        private LogFile logFile;

        [SetUp]
        public void Setup()
        {
            logFile = new LogFile("logfile.txt");

        }

        // Testing log for locked door
        [Test]
        public void Test_DoorLocked_logfileReceivesCorrectString()
        {
            string filepath = Directory.GetCurrentDirectory();
            logFile.LogWhenDoorLock(1);
            string[] lines = File.ReadAllLines(filepath + @"\file.txt");

            String Text = lines[^1];
            Assert.That(Text, Is.EqualTo(DateTime.Now + ": Skab låst med RFID: 1"));
        }

        // Testing log for unlocked door
        public void Test_DoorUnlocked_logfileReceivesCorrectString()
        {
            string filepath = Directory.GetCurrentDirectory();
            logFile.LogWhenDoorUnlock(1);
            string[] lines = File.ReadAllLines(filepath + @"\file.txt");

            String Text = lines[^1];
            Assert.That(Text, Is.EqualTo(DateTime.Now + ": Skab låst op med RFID: 1"));
        }


    }
}
