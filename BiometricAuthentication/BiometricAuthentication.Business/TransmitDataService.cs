
using BiometricAuthentication.Business.Encryption;
using BiometricAuthentication.Common.Events;
using BiometricAuthentication.Common.Sensors;
using System;

namespace BiometricAuthentication.Business
{
    //data transfer
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

        public CommunicationEventStatus SendDataPlainText(string dataToTransmit, GaitReadings gaitReadings, Guid deviceId)
        {

            _communicationEventArgs = new CommunicationEventArgs();
            _communicationEventArgs.Data = dataToTransmit;
            _communicationEventArgs.GaitReadingsChecksum = GenerateChecksum(gaitReadings);
            _communicationEventArgs.DeviceId = deviceId;

            TransmitData(_communicationEventArgs);

            return _communicationEventArgs.Status;
        }

        public CommunicationEventStatus SendData(string dataToTransmit, GaitReadings gaitReadings, Guid deviceId)
        {
            if (!string.IsNullOrEmpty(_encryptionKey))
            {
                var encryptionService = new EncryptionService();
                var encryptedData = encryptionService.encrypt(dataToTransmit, _encryptionKey);

                _communicationEventArgs = new CommunicationEventArgs();
                _communicationEventArgs.Data = encryptedData;
                Console.WriteLine("Plain text converted to cipher text :" + encryptedData);
                _communicationEventArgs.GaitReadingsChecksum = GenerateChecksum(gaitReadings);
                Console.WriteLine("Checksum Generated");
                _communicationEventArgs.DeviceId = deviceId;

                Console.WriteLine(" " + TransmitData);
                TransmitData(_communicationEventArgs);

                return _communicationEventArgs.Status;
            }

            return CommunicationEventStatus.SessionNotActive;
        }

        private GaitReadingsChecksum GenerateChecksum(GaitReadings gaitReadings)
        {
            //three arrays together in one
            Console.WriteLine("Generate Checksum");
            var allReadings = new double[150];
            gaitReadings.AccelerometerReadings.XValues.CopyTo(allReadings, 0);
            gaitReadings.AccelerometerReadings.YValues.CopyTo(allReadings, 49);
            gaitReadings.AccelerometerReadings.ZValues.CopyTo(allReadings, 99);

            var random = new Random();

            int[] positions = new int[9];
            double checksum = 0;

            for (int i = 0; i < positions.Length; i++)
            {
                var randomPosition = random.Next(0, 149);
                positions[i] = randomPosition;
                checksum = checksum + allReadings[randomPosition];
                Console.WriteLine("Value To Store in Checksum Array Position : " + i);
                Console.WriteLine("Value Extracted From Gait Array Table Position : " + positions[i]);
                Console.WriteLine(" Checksum Total = : " + checksum);
                
            }

            return new GaitReadingsChecksum(positions, checksum); 
        }

    }
}
