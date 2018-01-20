
using BiometricAuthentication.Common.Events;
using System;

namespace BiometricAuthentication.Business
{
    public class WearableDevicePairingResult
    {
        //Watch info section
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

        //Smartphone info section
        public WearableDevicePairingResult PairWearableDevice(Guid smartphoneId, string smartphoneName)
        {
            _pairingEventArgs = new PairingEventArgs();
            _pairingEventArgs.SmartphoneId = smartphoneId;
            _pairingEventArgs.SmartphoneName = smartphoneName;

            // DiscoverDevices holds smarthphone name & ID and returns smartphone details
            DiscoverDevices(_pairingEventArgs);

            //discovery of smartwatch
            //includes watch ID and watch name
            //returns data of both devices ID & Names paired together
            return 
                new WearableDevicePairingResult(_pairingEventArgs.WearableDeviceId, _pairingEventArgs.WearableDeviceName);
        }
    }
}
