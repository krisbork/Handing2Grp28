using Classes;
using Classes.EventArg;
using Classes.Interfaces;
using NUnit.Framework;
using NSubstitute;
//using CurrentEventArgs = Classes.Interfaces.CurrentEventArgs;

namespace Handin.Test.Unit
{
    public class ChargeControl_UTest
    {
        private ChargeControl _chargeControl;
        private IDisplay _display;
        private IUsbCharger _charger;

        [SetUp]
        public void Setup()
        {
            _charger = Substitute.For<IUsbCharger>();
            _display = Substitute.For<IDisplay>();
            _chargeControl = new ChargeControl(_charger, _display);
        }

        [Test]
        public void Test_PluggedInToggle()
        {
            Assert.That(_chargeControl.IsConnected, Is.EqualTo(false));
            _chargeControl.IsConnectedToggle();
            Assert.That(_chargeControl.IsConnected, Is.EqualTo(true));
            _chargeControl.IsConnectedToggle();
            Assert.That(_chargeControl.IsConnected, Is.EqualTo(false));
        }

        [Test]
        public void Test_StartChargeWhileUnplugged()
        {
            _chargeControl.StartCharge();
            _charger.Received(0).StartCharge();
        }

        [Test]
        public void Test_StartChargeWhilePluggedIn()
        {
            _chargeControl.IsConnectedToggle();
            _chargeControl.StartCharge();
            _charger.Received(1).StartCharge();
        }

        [Test]
        public void Test_StopChargeWhilePluggedIn()
        {
            _chargeControl.IsConnectedToggle();
            _chargeControl.StartCharge();
            _chargeControl.StopCharge();
            _charger.Received(1).StopCharge();
        }

        [Test]
        public void Test_StopChargeWithNothingPluggedIn()
        {
            _chargeControl.StopCharge();
            _charger.Received(1).StopCharge();
        }

        [Test]
        public void Test_mA_AboveAllowedAmount()
        {
            _charger.CurrentValueEvent += Raise.EventWith(null, new CurrentEventArgs() {Current = 600});
            _display.Received(1).DisplayMsg(MessageType.ChargeError);
        }

        [Test]
        public void Test_mA_ChargingNormally()
        {
            _charger.CurrentValueEvent += Raise.EventWith(null, new CurrentEventArgs() {Current = 350});
            _display.Received(1).DisplayMsg(MessageType.PhoneCharging);
        }

        [Test]
        public void Test_mA_FullyCharged()
        {
            _charger.CurrentValueEvent += Raise.EventWith(null, new CurrentEventArgs() {Current = 3});
            _display.Received(1).DisplayMsg(MessageType.PhoneFullyCharged);
        }
    }
}
