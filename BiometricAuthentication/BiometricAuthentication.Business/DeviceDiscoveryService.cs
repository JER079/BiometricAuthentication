
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

        public WearableDevicePairingResult PairWearableDevice(Guid smartphoneId, string smartphoneName)
        {
            _pairingEventArgs = new PairingEventArgs();
            _pairingEventArgs.SmartphoneId = smartphoneId;
            _pairingEventArgs.SmartphoneName = smartphoneName;

            Console.WriteLine("Smartphone Discovers New Device for Pairing");
            DiscoverDevices(_pairingEventArgs);
           


            //WearableDeviceID & WearableDeviceName are being added into the smartphone
            //return the watch Name & ID to smartphone
            return
                new WearableDevicePairingResult(_pairingEventArgs.WearableDeviceId, _pairingEventArgs.WearableDeviceName);
        }
    }
}
