using Common;
using Common.Events;
using System;

namespace BiometricAuthentication.Business
{
    public class TransmitDataService
    {
        public event TransmitDataHandler TransmitData;
        private CommunicationEventArgs _communicationEventArgs;
        public delegate void TransmitDataHandler(CommunicationEventArgs communicationEventArgs);

        public void SendData(string dataToTransmit, GaitReadings gaitReadings, Guid deviceId)
        {
            _communicationEventArgs = new CommunicationEventArgs();
            _communicationEventArgs.Data = dataToTransmit;
            _communicationEventArgs.GaitReadings = gaitReadings;
            _communicationEventArgs.DeviceId = deviceId;

            TransmitData(_communicationEventArgs);
        }

    }
}
