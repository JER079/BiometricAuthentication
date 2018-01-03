
using BiometricAuthentication.Business.Encryption;
using BiometricAuthentication.Common.Events;
using BiometricAuthentication.Common.Sensors;
using System;

namespace BiometricAuthentication.Business
{
    public class TransmitDataService
    {
        private string _encryptionKey;

        public event TransmitDataHandler TransmitData;
        private CommunicationEventArgs _communicationEventArgs;
        public delegate void TransmitDataHandler(CommunicationEventArgs communicationEventArgs);

        public void SetEncryptionKey(string encryptionKey)
        {
            _encryptionKey = encryptionKey;
        }

        public void SendData(string dataToTransmit, GaitReadings gaitReadings, Guid deviceId)
        {
            if (!string.IsNullOrEmpty(_encryptionKey))
            {
                var encryptionService = new EncryptionService();
                var encryptedData = encryptionService.encrypt(dataToTransmit, _encryptionKey);

                _communicationEventArgs = new CommunicationEventArgs();
                _communicationEventArgs.Data = encryptedData;
                _communicationEventArgs.GaitReadings = gaitReadings;
                _communicationEventArgs.DeviceId = deviceId;

                TransmitData(_communicationEventArgs);
            }
            
        }

    }
}
