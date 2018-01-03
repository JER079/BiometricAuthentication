using BiometricAuthentication.Common.Events;

namespace BiometricAuthentication.Business.Devices
{
    public class ManInTheMiddle
    {
        public string LastSniffedMessage;

        public void SubscribeForEvents(WearableDevice wearableDevice)
        {
            wearableDevice.DataTransmitter.TransmitData += DataTransmitter_TransmitData;
        }

        private void DataTransmitter_TransmitData(CommunicationEventArgs communicationEventArgs)
        {
            LastSniffedMessage = communicationEventArgs.Data;
        }
    }
}
