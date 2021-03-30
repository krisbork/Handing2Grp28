using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using Classes.EventArg;
using Classes.Interfaces;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;

namespace Handin.Test.Unit
{
    public class RFIDReader_UTest
    {
        private rfidReader _rfidReader;
        private RFIDEventArgs _rfidReadEvent;

        [SetUp]
        public void Setup()
        {
            _rfidReader = new rfidReader();
            _rfidReader.RFIDReadEvent += (o, args) => _rfidReadEvent = args;
        }

        [Test]
        public void Test_RFIDReader_ReadsCorrectNumber()
        {
            _rfidReader.ScanRFID(123);
            Assert.That(_rfidReadEvent.id, Is.EqualTo(123));
        }
    }
}