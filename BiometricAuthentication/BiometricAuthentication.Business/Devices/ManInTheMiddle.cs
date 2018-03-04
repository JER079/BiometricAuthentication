using BiometricAuthentication.Common;
using BiometricAuthentication.Common.Events;
using BiometricAuthentication.Common.Sensors;
using System;
using static BiometricAuthentication.Business.TransmitDataService;

namespace BiometricAuthentication.Business.Devices
{
    public class ManInTheMiddle
    {
        public string LastSniffedMessage;
        private CommunicationEventArgs _communicationEventArgs;
        public event TransmitDataHandler TransmitData;
        private Accelerometer _accelerometer;
        private Guid _deviceId;
        public delegate void TransmitDataHandler(CommunicationEventArgs communicationEventArgs);

        public ManInTheMiddle()
        { 
            _deviceId = Guid.Parse("07835692-36F5-431B-83E6-DCF661101A01"); //this is the device id of smartwatch
            _accelerometer = new Accelerometer();
        }

        public void SubscribeForEvents(WearableDevice wearableDevice)
        {
            wearableDevice.DataTransmitter.TransmitData += DataTransmitter_TransmitData;
        }

        private void DataTransmitter_TransmitData(CommunicationEventArgs communicationEventArgs)
        {
            LastSniffedMessage = communicationEventArgs.Data;
            Console.WriteLine("Man in the middle received : " + LastSniffedMessage);
        }

        public void TransmitDataToPhone()
        {
            SendData("HELLO", new GaitReadings(GetLatestReadings()), _deviceId);
        }

        public AccelerometerReadings GetLatestReadings()
        {
            return _accelerometer.GetLatestReadings();
        }

        private CommunicationEventStatus SendData(string dataToTransmit, GaitReadings gaitReadings, Guid deviceId)
        {
            string dataToSend = "hello";

            _communicationEventArgs = new CommunicationEventArgs();
            _communicationEventArgs.Data = dataToSend;
            _communicationEventArgs.GaitReadingsChecksum = GenerateChecksum(gaitReadings);
            _communicationEventArgs.DeviceId = deviceId;

            TransmitData(_communicationEventArgs);

            return _communicationEventArgs.Status;

        }

        private GaitReadingsChecksum GenerateChecksum(GaitReadings gaitReadings)
        {
            //three arrays together in one
            var allReadings = new double[150];
            gaitReadings.AccelerometerReadings.XValues.CopyTo(allReadings, 0);
            gaitReadings.AccelerometerReadings.YValues.CopyTo(allReadings, 49);
            gaitReadings.AccelerometerReadings.ZValues.CopyTo(allReadings, 99);

            var random = new Random(DateTime.Now.Second);

            int[] positions = new int[9];
            double checksum = 0;

            for (int i = 0; i < positions.Length; i++)
            {
                var randomPosition = random.Next(0, 149);
                positions[i] = randomPosition;
                checksum = checksum + allReadings[randomPosition];
            }

            return new GaitReadingsChecksum(positions, checksum);
        }
    }
}
//