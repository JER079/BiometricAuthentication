using Common.Events;
using System;

namespace BiometricAuthentication.Business
{
    public class WearableDevicePairingResult
    {
        public WearableDevicePairingResult(Guid deviceId, string deviceName)
        {
            WearableDeviceId = deviceId;
            WearableDeviceName = deviceName;
        }

        public Guid WearableDeviceId;
        public string WearableDeviceName;
    }

    public class DeviceDiscoveryService
    {
        public event PairingHandler DiscoverDevices;
        private PairingEventArgs _pairingEventArgs;
        public delegate void PairingHandler(PairingEventArgs pairingEventArgs);

        public WearableDevicePairingResult PairWearableDevice(Guid smartphoneId, string smartphoneName)
        {
            _pairingEventArgs = new PairingEventArgs();
            _pairingEventArgs.SmartphoneId = smartphoneId;
            _pairingEventArgs.SmartphoneName = smartphoneName;

            DiscoverDevices(_pairingEventArgs);

            return 
                new WearableDevicePairingResult(_pairingEventArgs.WearableDeviceId, _pairingEventArgs.WearableDeviceName);
        }
    }
}
