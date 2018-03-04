using BiometricAuthentication.Common;
using BiometricAuthentication.Common.Events;
using BiometricAuthentication.Common.Sensors;
using System;

namespace BiometricAuthentication.Business.Devices
{
    public class WearableDevice
    {
        public event SessionHandler RaiseStartNewSession;
        public SessionEventArgs sessionEventArgs;
        public delegate void SessionHandler(GaitReadings gaitReadings, SessionEventArgs sessionEventArgs);

        private readonly Accelerometer _accelerometer;
        public readonly TransmitDataService DataTransmitter;
        private readonly Guid _deviceId;
        public string Name { get; }

        private int _communicationRetries;

        public WearableDevice(Accelerometer accelerometer, 
                              DeviceDiscoveryService deviceDiscoveryService,
                              TransmitDataService transmitDataService)
        {
            _deviceId = Guid.Parse("07835692-36F5-431B-83E6-DCF661101A01");

            Name = "Jeremy's Watch";

            _accelerometer = accelerometer;
            DataTransmitter = transmitDataService;
            deviceDiscoveryService.DiscoverDevices += DeviceDiscoveryService_DiscoverDevices;
        }
        
        //combining both the Phone and Watch data together in pairingEventArgs
        //&
        //returns info to Class DeviceDiscoveryService into DiscoverDevices
        private void DeviceDiscoveryService_DiscoverDevices(PairingEventArgs pairingEventArgs)
        {
            //pairingEventArgs (the phone) with the addition of the WearableDeviceID & Name
            pairingEventArgs.WearableDeviceId = _deviceId;
            pairingEventArgs.WearableDeviceName = Name;
            Console.WriteLine("Wearable Device broadcasts :" + Name);
            Console.WriteLine("Wearable Device broadcasts :" + _deviceId );
        }

        //in this section to initiate a new session the watch will return its gaitreadings, sessionEventArgs and deviceID
        public void StartNewSession()
        {
            Console.WriteLine("Wearable Device wants to start a New Session");
            //from the Accelerometer Class
            Console.WriteLine("1st -> Extract New Gait Readings");
            var gaitReadings = new GaitReadings(GetLatestReadings());
            Console.WriteLine("New Gait Readings Extracted");
            //new SessionEventArgs to be delivered from phone
            sessionEventArgs = new SessionEventArgs();
            sessionEventArgs.WearbleDeviceId = _deviceId;
            Console.WriteLine("2nd -> Wearable Device ID stored in SessionEventArgs");

            Console.WriteLine("3rd -> Wearable Device Requests Smartphone to Start a New Session");
            Console.WriteLine("Sends Gait Readings and SessionEventArgs to Smartphone");
            RaiseStartNewSession(gaitReadings, sessionEventArgs);

            DataTransmitter.SetEncryptionKey(sessionEventArgs.EncryptionKey);
        }

        public void TransmitDataPlainText(string dataToTransmit)
        {
            var status = DataTransmitter.SendDataPlainText(dataToTransmit, new GaitReadings(GetLatestReadings()), _deviceId);
            ProcessCallback(dataToTransmit, status);
        }

        public void TransmitData(string dataToTransmit)
        {

            var status = DataTransmitter.SendData(dataToTransmit, new GaitReadings(GetLatestReadings()), _deviceId);
            Console.WriteLine("Sending Cipher Text, New Gait Readings and Device"); 
            ProcessCallback(dataToTransmit, status);
        }

        // retries 
        private void ProcessCallback(string dataToTransmit, CommunicationEventStatus status)
        {
            if (status == CommunicationEventStatus.Ok)
            {
                _communicationRetries = 0;
            }
            // SessionNotActive = 2
            else if (status == CommunicationEventStatus.SessionNotActive)
            {
                StartNewSession();
                DataTransmitter.SendData(dataToTransmit, new GaitReadings(GetLatestReadings()), _deviceId);
            }
                else if (status == CommunicationEventStatus.ChecksumNotMatched && _communicationRetries < 3)
            {
                DataTransmitter.SendData(dataToTransmit, new GaitReadings(GetLatestReadings()), _deviceId);
                _communicationRetries++;
            }
        }

        //gets GetLatestReadings data from the AccelerometerReadings Class
        public AccelerometerReadings GetLatestReadings()
        {
            
            return _accelerometer.GetLatestReadings();
            //Console.WriteLine("New Gait Readings");
        }
    }
}
