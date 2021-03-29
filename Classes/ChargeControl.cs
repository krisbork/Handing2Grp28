using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Interfaces;

namespace Classes
{
    public class ChargeControl : IChargeControl
    {
        private IUsbCharger _charger;
        private IDisplay _display;
        private bool isConnected = false;
        public ChargeControl(IUsbCharger charger, IDisplay display)
        {
            this._charger = charger;
            this._display = display;
            this._charger.CurrentValueEvent += chargerCurrent_CurrentValueEvent;
        }

        private void chargerCurrent_CurrentValueEvent(object sender, CurrentEventArgs e)
        {
            if (e.Current > 0 && e.Current <= 5)
                _display.DisplayMsg(MessageType.PhoneFullyCharged);
            else if (e.Current > 5 && e.Current <= 500)
                _display.DisplayMsg(MessageType.PhoneCharging);
            else if (e.Current > 500)
            {
                StopCharge();
                _display.DisplayMsg(MessageType.ChargeError);
            }
        }

        public bool IsConnected()
        {
            return isConnected;
        }

        public void StartCharge()
        {
            if (isConnected)
                _charger.StartCharge();
        }

        public void StopCharge()
        {
            _charger.StopCharge();
        }

        public void IsConnectedToggle()
        {
            if (isConnected == true)
                isConnected = false;
            else if (isConnected == false)
                isConnected = true;
        }
    }
}
