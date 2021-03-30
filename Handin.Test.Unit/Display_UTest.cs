using System;
using System.IO;
using Classes;
using Classes.Interfaces;
using NUnit.Framework;

namespace Handin.Test.Unit
{
    public class Display_UTest
    {
        private Display _display;
        [SetUp]
        public void Setup()
        {
            _display = new Display();
        }

        [Test]
        [TestCase(MessageType.RfidRead, "Put RFID tag in front of reader to unlock.\r\n")]
        [TestCase(MessageType.RfidError, "Error reading RFID tag.\r\n")]
        [TestCase(MessageType.RfidWrong, "Wrong RFID tag.\r\n")]
        [TestCase(MessageType.ConnectPhone, "Please connect phone.\r\n")]
        [TestCase(MessageType.DisconnectPhone, "Please disconnect phone.\r\n")]
        [TestCase(MessageType.ConnectionError, "Error connecting to phone.\r\n")]
        [TestCase(MessageType.PhoneFullyCharged, "Phone is fully charged.\r\n")]
        [TestCase(MessageType.PhoneCharging, "Phone is charging.\r\n")]
        [TestCase(MessageType.ChargeError, "Error occurred while charging.\r\n")]
        [TestCase(MessageType.ChargeStationInUse, "Charging station in use.\r\n")]

        public void Test_CorrectOutputs(MessageType messageType, string outputResult)
        {
            var output = new StringWriter();
            Console.SetOut(output);

            _display.DisplayMsg(messageType);

            Assert.That(output.ToString(), Is.EqualTo(outputResult));
        }

    }
}
