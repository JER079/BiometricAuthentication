using Common;
using System;

namespace BiometricAuthentication.Business
{
    public class WearableDevice
    {
        public event SessionHandler RaiseStartNewSession;
        public SessionEventArgs sessionEventArgs;
        public delegate void SessionHandler(GaitReadings gaitReadings, SessionEventArgs sessionEventArgs);

        private readonly Accelerometer _accelerometer;

        private readonly Guid _deviceId;
        private readonly string _deviceName;

        public WearableDevice(Accelerometer accelerometer, 
                              DeviceDiscoveryService deviceDiscoveryService)
        {
            _deviceId = Guid.NewGuid();
            _deviceName = "Jonathan's Watch";

            _accelerometer = accelerometer;

            deviceDiscoveryService.DiscoverDevices += DeviceDiscoveryService_DiscoverDevices;
        }

        private void DeviceDiscoveryService_DiscoverDevices(Common.Events.PairingEventArgs pairingEventArgs)
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


        }

        public AccelerometerReadings GetLatestReadings()
        {
            return _accelerometer.GetLatestReadings();
        }
    }
}
