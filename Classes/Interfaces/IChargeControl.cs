namespace Classes.Interfaces
{
    public interface IChargeControl
    {
        public bool IsConnected();
        public void StartCharge();
        public void StopCharge();
    }
}
