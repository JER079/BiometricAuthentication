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
        private readonly string _deviceName;

        public WearableDevice(Accelerometer accelerometer, 
                              DeviceDiscoveryService deviceDiscoveryService,
                              TransmitDataService transmitDataService)
        {
            _deviceId = Guid.NewGuid();
            _deviceName = "Jonathan's Watch";

            _accelerometer = accelerometer;
            DataTransmitter = transmitDataService;
            deviceDiscoveryService.DiscoverDevices += DeviceDiscoveryService_DiscoverDevices;
        }

        private void DeviceDiscoveryService_DiscoverDevices(PairingEventArgs pairingEventArgs)
        {
            pairingEventArgs.WearableDeviceId = _deviceId;
            pairingEventArgs.WearableDeviceName = _deviceName;
        }

        public void StartNewSession()
        {
            var gaitReadings = new GaitReadings(GetLatestReadings());
            sessionEventArgs = new SessionEventArgs();
            sessionEventArgs.WearbleDeviceId = _deviceId;
            
            RaiseStartNewSession(gaitReadings, sessionEventArgs);

            DataTransmitter.SetEncryptionKey(sessionEventArgs.EncryptionKey);
        }

        public void TransmitData(string dataToTransmit)
        {
            DataTransmitter.SendData(dataToTransmit, new GaitReadings(GetLatestReadings()), _deviceId);
        }

        public AccelerometerReadings GetLatestReadings()
        {
            return _accelerometer.GetLatestReadings();
        }
    }
}
